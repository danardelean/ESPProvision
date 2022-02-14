using System;
using Shiny.BluetoothLE;

namespace ESPProvision
{
    public interface IBleScanListener
    {
        void ScanStartFailed();
        void OnPeripheralFound(IPeripheral device);
        void ScanCompleted();
        void OnFailure(Exception e);
    }
}
