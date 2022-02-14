using System;
using System.Collections.Generic;
using ESPProvision.Interfaces;
using Shiny.BluetoothLE;
using Xamarin.Forms;

namespace ESPProvision
{
    public partial class MainPage : ContentPage, IBleScanListener,IWiFiScanListener,IProvisionListener
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnFailure(Exception e)
        {

        }

        IPeripheral _device;
        public void OnPeripheralFound(IPeripheral device)
        {
            _device = device;
            tstButton.Text = device.Name;
            tstButton.IsVisible = true;
            tstButton.IsEnabled = true;
        }

        public void ScanCompleted()
        {

        }

        public void ScanStartFailed()
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ESPProvisionManager.Instance.StartScan(this);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ESPProvisionManager.Instance.StopScan();
        }
        ESPDevice esp;
        async void tstButton_Clicked(System.Object sender, System.EventArgs e)
        {
            
            ESPProvisionManager.Instance.StopScan();

            esp = new ESPDevice(TransportType.TRANSPORT_BLE, SecurityType.SECURITY_0);
            if (await esp.ConnectToDeviceAsync(_device))
            {
                tstButton.IsEnabled = false;
                btnScan.IsVisible = true;
            }

        }

        public void OnWifiListReceived(List<WiFiAccessPoint> wifiList)
        {
            btnScan.IsEnabled = true;
            btnProvision.IsVisible = true;
            lstTest.ItemsSource = wifiList;
            //esp.Disconnect();
        }

        public void OnWiFiScanFailed(Exception e)
        {
            btnScan.IsEnabled = true;
            btnProvision.IsVisible = false;
            bool bp = true;
        }

        void btnScan_Clicked(System.Object sender, System.EventArgs e)
        {
            btnScan.IsEnabled = false;
            esp.ScanNetworks(this);
        }

        void btnProvision_Clicked(System.Object sender, System.EventArgs e)
        {
            btnProvision.IsEnabled = false;
            btnScan.IsEnabled = false;
            esp.Provision("CADAMAMA", "ma2013ca0278da0879ma1215", this);
        }

        public void CreateSessionFailed(Exception e)
        {
            btnProvision.IsEnabled = true;
            btnScan.IsEnabled = true;
        }

        public void WifiConfigSent()
        {
           
        }

        public void WifiConfigFailed(Exception e)
        {
            btnProvision.IsEnabled = true;
            btnScan.IsEnabled = true;
        }

        public void WifiConfigApplied()
        {
           
        }

        public void WifiConfigApplyFailed(Exception e)
        {
            btnProvision.IsEnabled = true;
            btnScan.IsEnabled = true;
        }

        public void ProvisioningFailedFromDevice(ProvisionFailureReason failureReason)
        {
            btnProvision.IsEnabled = true;
            btnScan.IsEnabled = true;
        }

        public void DeviceProvisioningSuccess()
        {
            esp.Disconnect();

            btnProvision.IsEnabled = true;
            btnScan.IsEnabled = true;
            btnProvision.IsVisible = false;
            btnScan.IsVisible = false;
            lstTest.ItemsSource = null;
            ESPProvisionManager.Instance.StartScan(this);
        }

        public void OnProvisioningFailed(Exception e)
        {
            btnProvision.IsEnabled = true;
            btnScan.IsEnabled = true;
        }
    }
}
