using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ESPProvision.Transport;
using Shiny;
using Shiny.BluetoothLE;

namespace ESPProvision
{
    public class BleTransport : ITransport
    {
        Dictionary<string, Tuple<string, string>> uuidMap = new Dictionary<string, Tuple<string, string>>();
        IBleManager _bleManager;
        public BleTransport()
        {
            _bleManager = ShinyHost.Resolve<IBleManager>();

            uuidMap.Add(ESPConstants.HANDLER_PROV_SCAN, new Tuple<string, string>("021a9004-0382-4aea-bff4-6b3f1c5adfb4", "021aff50-0382-4aea-bff4-6b3f1c5adfb4"));
            uuidMap.Add(ESPConstants.HANDLER_PROV_SESSION, new Tuple<string, string>("021a9004-0382-4aea-bff4-6b3f1c5adfb4", "021aff51-0382-4aea-bff4-6b3f1c5adfb4"));
            uuidMap.Add(ESPConstants.HANDLER_PROV_CONFIG, new Tuple<string, string>("021a9004-0382-4aea-bff4-6b3f1c5adfb4", "021aff52-0382-4aea-bff4-6b3f1c5adfb4"));
            uuidMap.Add(ESPConstants.HANDLER_PROTO_VER, new Tuple<string, string>("021a9004-0382-4aea-bff4-6b3f1c5adfb4", "021aff53-0382-4aea-bff4-6b3f1c5adfb4"));

        }

        public async void SendConfigData(string path, byte[] data, IResponseListener listener)
        {
            if (_currentDevice == null || _currentDevice.Status != ConnectionState.Connected)
            {
                listener?.OnFailure(new Exception("Device is not connected"));
                return;
            }
            if (!uuidMap.ContainsKey(path))
            {
                listener?.OnFailure(new Exception("Characteristic is not available for given path."));
                _currentDevice.CancelConnection();
                return;
            }

            var c = await _currentDevice.GetKnownCharacteristic(uuidMap[path].Item1, uuidMap[path].Item2);
            var r = await c.WriteAsync(data, true);
            //await Task.Delay(TimeSpan.FromSeconds(0.5));
            var result = await c.ReadAsync();
            listener?.OnSuccess(result.Data);
        }

        IPeripheral _currentDevice;
        public async Task<bool> ConnectAsync(IPeripheral device)
        {
            _currentDevice = device;
            if (_bleManager.IsScanning)
                _bleManager.StopScan();
            ConnectionConfig config = new ConnectionConfig()
            {
                AndroidConnectionPriority = ConnectionPriority.High,
            };
            await _currentDevice.ConnectAsync(config);
            if (_currentDevice.Status != ConnectionState.Connected)
            {
                return false;
            }

            var services = await device.GetServices();
            if (services != null && services.Count > 0)
            {
                foreach (var service in services)
                    await service.GetCharacteristicsAsync();
            }
            if (uuidMap.Count >= 4)
                return true;
            _currentDevice.CancelConnection();
            return false;
        }

        public void Disconnect()
        {
            if (_currentDevice!=null&&_currentDevice.Status!= ConnectionState.Disconnected)
            {
                _currentDevice.CancelConnection();
                _currentDevice = null;
            }
        }
    }
}
