using System;
namespace ESPProvision
{
    public class WiFiAccessPoint
    {
        public string WifiName { get; set; } // SSID
        public int Rssi { get; set; }
        public int Security { get; set; }
        public string Password { get; set; }
    }
}
