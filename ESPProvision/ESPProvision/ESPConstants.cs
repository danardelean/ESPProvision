using System;
namespace ESPProvision
{
    public class ESPConstants
    {
        public const string DEFAULT_WIFI_BASE_URL = "192.168.4.1:80";

        // End point names
        public const string HANDLER_PROV_SCAN = "prov-scan";
        public const string HANDLER_PROTO_VER = "proto-ver";
        public const string HANDLER_PROV_SESSION = "prov-session";
        public const string HANDLER_PROV_CONFIG = "prov-config";

        // Event types
        public const short EVENT_DEVICE_CONNECTED = 1;
        public const short EVENT_DEVICE_CONNECTION_FAILED = 2;
        public const short EVENT_DEVICE_DISCONNECTED = 3;

        // Constants for WiFi Security values (As per proto files)
        public const short WIFI_OPEN = 0;
        public const short WIFI_WEP = 1;
        public const short WIFI_WPA_PSK = 2;
        public const short WIFI_WPA2_PSK = 3;
        public const short WIFI_WPA_WPA2_PSK = 4;
        public const short WIFI_WPA2_ENTERPRISE = 5;
    }
    public enum TransportType
    {
        TRANSPORT_BLE,
        TRANSPORT_SOFTAP
    }

    public enum SecurityType
    {
        SECURITY_0,
        SECURITY_1
    }

    public enum ProvisionFailureReason
    {
        AUTH_FAILED,
        NETWORK_NOT_FOUND,
        DEVICE_DISCONNECTED,
        UNKNOWN
    }
}
