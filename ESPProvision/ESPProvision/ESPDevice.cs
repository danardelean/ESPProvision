using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESPProvision.Interfaces;
using ESPProvision.Listeners;
using ESPProvision.Security;
using ESPProvision.Transport;
using ESPProvision.Utils;
using Espressif;
using Google.Protobuf;
using Shiny.BluetoothLE;

namespace ESPProvision
{
    public class ESPDevice
    {
        private const string TAG = "ESP:" + nameof(ESPDevice);

        private Session session;
        private ISecurity security;
        private ITransport transport;

        private IProvisionListener provisionListener;
        private IWiFiScanListener wifiScanListener;
        private IResponseListener responseListener;
        private TransportType transportType;
        private SecurityType securityType;

        private string versionInfo;
        private int totalCount;
        private int startIndex;

        private string primaryServiceUuid;
        private string deviceName;
        List<WiFiAccessPoint> wifiApList;

        public ESPDevice(TransportType transportType, SecurityType securityType)
        {
            this.transportType = transportType;
            this.securityType = securityType;
        }

        public void Provision(string ssid, string passphrase, IProvisionListener provisionListener)
        {
            this.provisionListener = provisionListener;
            SendWiFiConfig(ssid, passphrase, provisionListener);
        }

        int _totalCount;
        int _startIndex;

        private void StartNetworkScan()
        {
            _totalCount = 0;
            _startIndex = 0;
            wifiApList = new List<WiFiAccessPoint>();
            SendWifiScanMsg();
        }

        void SendWifiScanMsg()
        {
            byte[] scanCommand = MessengeHelper.PrepareWiFiScanMsg();
            session.SendDataToDevice(ESPConstants.HANDLER_PROV_SCAN, scanCommand, new ResponseListener(
                onSuccess: (returnData) =>
                {
                    ProcessWiFiScanPayloadResponse(returnData);
                },
                onFailure: (Exception ex) =>
                {
                    wifiScanListener?.OnWiFiScanFailed(new Exception("Failed to send Wi-Fi scan command."));
                }));
        }

        void SendWifiStatusMsg()
        {
            byte[] getScanStatusCmd = MessengeHelper.PrepareGetWiFiScanStatusMsg();
            session.SendDataToDevice(ESPConstants.HANDLER_PROV_SCAN, getScanStatusCmd, new ResponseListener(
                onSuccess: (scanData) =>
                {
                    ProcessWiFiScanPayloadResponse(scanData);
                },
                onFailure: (e) =>
                {
                    wifiScanListener?.OnWiFiScanFailed(new Exception("Failed to send Wi-Fi scan command."));
                }));
        }

        private void ProcessWiFiScanPayloadResponse(byte[] responseData)
        {
            try
            {
                WiFiScanPayload payload = WiFiScanPayload.Parser.ParseFrom(responseData);

                switch(payload.Msg)
                {
                    case WiFiScanMsgType.TypeRespScanResult:
                        ProcessGetSSIDs(payload.RespScanResult);
                        break;
                    case WiFiScanMsgType.TypeRespScanStart:
                        SendWifiStatusMsg();
                        break;
                    case WiFiScanMsgType.TypeRespScanStatus:
                        if (payload.RespScanStatus.ScanFinished)
                        {
                            startIndex = 0;
                            totalCount = (int)payload.RespScanStatus.ResultCount;
                            GetFullWiFiList();
                        }
                        else
                            SendWifiStatusMsg();
                        break;
                    default:
                        SendWifiStatusMsg();
                        break;
                }
            }
            catch (Exception e)
            {
                wifiScanListener?.OnWiFiScanFailed(e);
            }
        }

       

        private void GetFullWiFiList()
        {
            if (totalCount < 4)
                GetWiFiScanList(0, totalCount);
            else
            {
                int temp = totalCount - startIndex;
                if (temp > 0)
                {
                    if (temp > 4)
                        GetWiFiScanList(startIndex, 4);
                    else
                        GetWiFiScanList(startIndex, temp);
                }
                else
                    wifiScanListener?.OnWifiListReceived(wifiApList);
            }
        }

        private void GetWiFiScanList(int start, int count)
        {
            if (count <= 0)
            {
                wifiScanListener?.OnWifiListReceived(wifiApList);
                return;
            }
            byte[] data = MessengeHelper.PrepareGetWiFiScanListMsg((uint)start, (uint)count);
            session.SendDataToDevice(ESPConstants.HANDLER_PROV_SCAN, data, new ResponseListener(
                onSuccess: (byte[] returnData) =>
                {
                    ProcessWiFiScanPayloadResponse(returnData);
                },
                onFailure: (e) =>
                 {
                     wifiScanListener?.OnWiFiScanFailed(new Exception("Failed to get Wi-Fi Networks."));
                 }));
        }

        private void ProcessGetSSIDs(RespScanResult response)
        {
            try
            {
                for (int i = 0; i < response.Entries.Count; i++)
                {
                    string ssid = response.Entries[i].Ssid.ToStringUtf8();
                    int rssi = response.Entries[i].Rssi;
                    bool isAvailable = false;

                    var wifi = wifiApList.Where(w => w.WifiName == ssid).FirstOrDefault();
                    if (wifi != null)
                    {
                        wifi.Rssi = rssi;
                        isAvailable = true;
                    }
                    if (!isAvailable)
                    {
                        WiFiAccessPoint wifiAp = new WiFiAccessPoint();
                        wifiAp.WifiName = ssid;
                        wifiAp.Rssi = rssi;
                        wifiAp.Security = (int)response.Entries[i].Auth;
                        wifiApList.Add(wifiAp);
                    }
                }
                startIndex = startIndex + 4;
                int temp = totalCount - startIndex;
                if (temp > 0)
                    GetFullWiFiList();
                else
                    wifiScanListener?.OnWifiListReceived(wifiApList);
            }
            catch (InvalidProtocolBufferException e)
            {
            }
        }

        private void SendWiFiConfig(string ssid, string passphrase, IProvisionListener provisionListener)
        {
            byte[] scanCommand = MessengeHelper.PrepareWiFiConfigMsg(ssid, passphrase);
            session.SendDataToDevice(ESPConstants.HANDLER_PROV_CONFIG, scanCommand, new ResponseListener(
                onSuccess: (byte[] data) =>
                 {
                     Status status = ProcessWifiConfigResponse(data);
                     if (provisionListener != null)
                     {
                         if (status != Status.Success)
                             provisionListener?.WifiConfigFailed(new Exception("Failed to send wifi credentials to device"));
                         else
                             provisionListener?.WifiConfigSent();
                     }

                     if (status == Status.Success)
                         ApplyWiFiConfig();
                 },
                onFailure: (Exception ex) =>
                 {
                     if (provisionListener != null)
                         provisionListener?.WifiConfigFailed(new Exception("Failed to send wifi credentials to device"));
                 }));
        }

        private Status ProcessWifiConfigResponse(byte[] responseData)
        {
            Status status = Status.InvalidSession;
            try
            {
                WiFiConfigPayload wiFiConfigPayload = WiFiConfigPayload.Parser.ParseFrom(responseData);
                status = wiFiConfigPayload.RespSetConfig.Status;
            }
            catch (InvalidProtocolBufferException e)
            {

            }
            return status;
        }


        private void ApplyWiFiConfig()
        {
            byte[] scanCommand = MessengeHelper.PrepareApplyWiFiConfigMsg();
            session.SendDataToDevice(ESPConstants.HANDLER_PROV_CONFIG, scanCommand, new ResponseListener(
                onSuccess: (byte[] returnData) =>
                {
                    Status status = ProcessApplyConfigResponse(returnData);
                    if (status == Status.Success)
                    {
                        if (provisionListener != null)
                            provisionListener?.WifiConfigApplied();
                        try
                        {
                            Thread.Sleep(2000);
                        }
                        catch (Exception e)
                        {
                        }
                        PollForWifiConnectionStatus();
                    }
                    else
                    {
                        provisionListener?.WifiConfigApplyFailed(new Exception("Failed to apply wifi credentials"));
                    }
                },
                onFailure: (Exception ex) =>
                {
                    provisionListener?.WifiConfigApplyFailed(new Exception("Failed to apply wifi credentials"));
                }));
        }

        private Status ProcessApplyConfigResponse(byte[] responseData)
        {
            Status status = Status.InvalidSession;
            try
            {
                WiFiConfigPayload wiFiConfigPayload = WiFiConfigPayload.Parser.ParseFrom(responseData);
                status = wiFiConfigPayload.RespApplyConfig.Status;
            }
            catch (InvalidProtocolBufferException e)
            {
            }
            return status;
        }

        private Object[] ProcessProvisioningStatusResponse(byte[] responseData)
        {
            WifiStationState wifiStationState = WifiStationState.Disconnected;
            WifiConnectFailedReason failedReason = WifiConnectFailedReason.NetworkNotFound;

            if (responseData == null)
            {
                return new Object[] { wifiStationState, failedReason };
            }

            try
            {
                WiFiConfigPayload wiFiConfigPayload = WiFiConfigPayload.Parser.ParseFrom(responseData);
                wifiStationState = wiFiConfigPayload.RespGetStatus.StaState;
                failedReason = wiFiConfigPayload.RespGetStatus.FailReason;
            }
            catch (InvalidProtocolBufferException e)
            {
            }
            return new Object[] { wifiStationState, failedReason };
        }

        private void PollForWifiConnectionStatus()
        {

            byte[] message = MessengeHelper.PrepareGetWiFiConfigStatusMsg();
            session.SendDataToDevice(ESPConstants.HANDLER_PROV_CONFIG, message, new ResponseListener(
                onSuccess: (byte[] returnData) =>
                 {
                     Object[] statuses = ProcessProvisioningStatusResponse(returnData);
                     WifiStationState wifiStationState = (WifiStationState)statuses[0];
                     WifiConnectFailedReason failedReason = (WifiConnectFailedReason)statuses[1];

                     if (wifiStationState == WifiStationState.Connected)
                     {
                         provisionListener?.DeviceProvisioningSuccess();
                         session = null;
                     }
                     else if (wifiStationState == WifiStationState.Disconnected)
                     {
                         provisionListener?.ProvisioningFailedFromDevice(ProvisionFailureReason.DEVICE_DISCONNECTED);
                         session = null;

                     }
                     else if (wifiStationState == WifiStationState.Connecting)
                     {
                         try
                         {
                             Thread.Sleep(5000);
                             PollForWifiConnectionStatus();
                         }
                         catch (Exception e)
                         {
                             session = null;
                             provisionListener?.OnProvisioningFailed(new Exception("Provisioning Failed"));
                         }
                     }
                     else
                     {
                         if (failedReason == WifiConnectFailedReason.AuthError)
                             provisionListener?.ProvisioningFailedFromDevice(ProvisionFailureReason.AUTH_FAILED);
                         else if (failedReason == WifiConnectFailedReason.NetworkNotFound)
                             provisionListener?.ProvisioningFailedFromDevice(ProvisionFailureReason.NETWORK_NOT_FOUND);
                         else
                             provisionListener?.ProvisioningFailedFromDevice(ProvisionFailureReason.UNKNOWN);
                         session = null;
                     }
                 },
                onFailure: (e) =>
                 {
                     provisionListener?.OnProvisioningFailed(new Exception("Provisioning Failed"));
                 }));
        }
        IPeripheral _bluetoothDevice;
        public Task<bool> ConnectToDeviceAsync(IPeripheral bluetoothDevice)
        {
            _bluetoothDevice = bluetoothDevice;
            switch (transportType)
            {
                case TransportType.TRANSPORT_BLE:
                    transport = new BleTransport();
                    return ((BleTransport)transport).ConnectAsync(_bluetoothDevice);
                case TransportType.TRANSPORT_SOFTAP:
                    //deviceConnectionReqCount = 0;
                    //connectWiFiDevice(wifiDevice.getWifiName(), wifiDevice.getPassword());
                    break;
            }
            return Task.FromResult(false);
        }
        public void Disconnect()
        {
            switch (transportType)
            {
                case TransportType.TRANSPORT_BLE:
                    ((BleTransport)transport)?.Disconnect();
                    break;
                case TransportType.TRANSPORT_SOFTAP:
                    //deviceConnectionReqCount = 0;
                    //connectWiFiDevice(wifiDevice.getWifiName(), wifiDevice.getPassword());
                    break;
            }
        }

        private void InitSession(IResponseListener listener)
        {
            if (securityType == SecurityType.SECURITY_0)
            {
                security = new Security0();
            }
            //else
            //{
            //    security = new Security1(proofOfPossession);
            //}
            session = new Session(transport, security);

            session.Init(null,
                new SessionListener(
                    onSessionEstablished: () =>
                     {
                         listener.OnSuccess(null);
                     },
                    onSessionEstablishFailed: (e) =>
                     {
                         listener?.OnFailure(e);
                     }));
        }

        public void ScanNetworks( IWiFiScanListener wifiScanListener)
        {
            this.wifiScanListener = wifiScanListener;
            if (session == null || !session.IsSessionEstablished)
            {
                InitSession(new ResponseListener(
                    onSuccess: (data) => StartNetworkScan(),
                    onFailure: (ex) => wifiScanListener?.OnWiFiScanFailed(new Exception("Failed to create session."))));
            } else {
                StartNetworkScan();
            }
    }
}
}
