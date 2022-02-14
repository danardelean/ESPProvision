 using System;
namespace ESPProvision
{
    public class ESPProvisionManager
    {
        private ESPDevice espDevice;
        BleScanner bleScanner;

        private static readonly Lazy<ESPProvisionManager> lazy = new Lazy<ESPProvisionManager>(() => new ESPProvisionManager());

        public static ESPProvisionManager Instance { get { return lazy.Value; } }

        BleTransport _transport;

        private ESPProvisionManager()
        {
            _transport = new BleTransport();
        }

        public ESPDevice CreateESPDevice(TransportType transportType, SecurityType securityType)
        {
            espDevice = new ESPDevice (transportType, securityType);
            return espDevice;
        }

        public void StartScan(IBleScanListener bleScannerListener)
        {
            bleScanner = new BleScanner( bleScannerListener);
            bleScanner.StartScan();
        }

        public void StopScan()
        {
            bleScanner?.StopScan();
        }
    }
}
