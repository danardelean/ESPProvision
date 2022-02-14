using System;
using System.Collections.Generic;

namespace ESPProvision.Interfaces
{
    public interface IWiFiScanListener
    {
        /**
    * Callback method to return a list of Wi-Fi access points.
    *
    * @param wifiList ArrayList of Wi-Fi access points.
    */
        void OnWifiListReceived(List<WiFiAccessPoint> wifiList);

        /**
         * Failed to scan for Wi-Fi devices.
         *
         * @param e Exception
         */
        void OnWiFiScanFailed(Exception e);
    }
}
