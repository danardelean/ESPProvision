using System;
using System.Text;
using Espressif;
using Google.Protobuf;

namespace ESPProvision.Utils
{
    public class MessengeHelper
    {
        // Send Wi-Fi Scan command
        public static byte[] PrepareWiFiScanMsg()
        {
            CmdScanStart configRequest = new CmdScanStart()
            {
                Blocking = true,
                Passive = false,
                GroupChannels = 0,
                PeriodMs = 120
            };

            WiFiScanPayload payload = new WiFiScanPayload()
            {
                CmdScanStart = configRequest,
                Msg = WiFiScanMsgType.TypeCmdScanStart
            };
            return payload.ToByteArray();
        }

        public static byte[] PrepareGetWiFiScanStatusMsg()
        {
            WiFiScanPayload payload = new WiFiScanPayload
            {
                Msg = WiFiScanMsgType.TypeCmdScanStatus,
                CmdScanStatus=new CmdScanStatus()

            };
            return payload.ToByteArray();
        }

        // Get Wi-Fi scan list
        public static byte[] PrepareGetWiFiScanListMsg(uint start, uint count)
        {
            CmdScanResult configRequest = new CmdScanResult
            {
                StartIndex=start,
                Count=count
            };

            WiFiScanPayload payload = new WiFiScanPayload
            {
                Msg = WiFiScanMsgType.TypeCmdScanResult,
                CmdScanResult=configRequest
            };

            return payload.ToByteArray();
        }

        // Send Wi-Fi Config
        public static byte[] PrepareWiFiConfigMsg(String ssid, String passphrase)
        {
            CmdSetConfig cmdSetConfig;
            if (passphrase != null)
            {
                cmdSetConfig = new CmdSetConfig
                {
                    Ssid=ByteString.CopyFrom(Encoding.UTF8.GetBytes(ssid)),
                    Passphrase= ByteString.CopyFrom(Encoding.UTF8.GetBytes(passphrase))
                };
            }
            else
            {
                cmdSetConfig = new CmdSetConfig
                {
                    Ssid = ByteString.CopyFrom(Encoding.UTF8.GetBytes(ssid)),
                };
            }
            WiFiConfigPayload wiFiConfigPayload = new WiFiConfigPayload()
            {
                CmdSetConfig=cmdSetConfig,
                Msg= WiFiConfigMsgType.TypeCmdSetConfig

            };
            return wiFiConfigPayload.ToByteArray();
        }

        // Apply Wi-Fi config
        public static byte[] PrepareApplyWiFiConfigMsg()
        {
            WiFiConfigPayload wiFiConfigPayload = new WiFiConfigPayload
            {
                CmdApplyConfig=new CmdApplyConfig(),
                Msg= WiFiConfigMsgType.TypeCmdApplyConfig
            };
            return wiFiConfigPayload.ToByteArray();
        }

        // Get Wi-Fi Config status
        public static byte[] PrepareGetWiFiConfigStatusMsg()
        {
            WiFiConfigPayload wiFiConfigPayload = new WiFiConfigPayload
            {
                CmdGetStatus=new CmdGetStatus(),
                Msg= WiFiConfigMsgType.TypeCmdGetStatus
            };
            return wiFiConfigPayload.ToByteArray();
        }

    }
}
