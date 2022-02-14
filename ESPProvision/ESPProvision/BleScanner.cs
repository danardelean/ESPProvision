using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ESPProvision.Utils;
using Shiny;
using Shiny.BluetoothLE;

namespace ESPProvision
{
    public class BleScanner
    {
        IBleScanListener _bleScanListener;
        IBleManager _bleManager;
        public BleScanner(IBleScanListener bleScannerListener)
        {
            _bleScanListener = bleScannerListener;
            _bleManager = ShinyHost.Resolve<IBleManager>();
        }

        public async void StartScan()
        {
            var status = await _bleManager.RequestAccess();
            if (status!= AccessState.Available||_bleManager.IsScanning)
            {
                _bleScanListener?.ScanStartFailed();
                return;
            }
            ScanConfig config = new ScanConfig()
            {
                ScanType = BleScanType.Balanced,
                AndroidUseScanBatching = false,
                ServiceUuids = new List<string> { "021a9004-0382-4aea-bff4-6b3f1c5adfb4" }
            };

            _bleManager.Scan(config).Buffer(TimeSpan.FromSeconds(1))
                            .Where(x => x?.Any() ?? false)
                            .SubOnMainThread(
                results =>
                {
                    foreach(var result in results)
                        _bleScanListener?.OnPeripheralFound(result.Peripheral);
                },
                ex => _bleScanListener?.OnFailure(ex));
        }

        public void StopScan()
        {
            if (_bleManager.IsScanning)
            {
                _bleManager.StopScan();
                _bleScanListener?.ScanCompleted();
            }
        }
    } 
}

