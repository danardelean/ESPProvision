using System;
using Espressif;
using Google.Protobuf;

namespace ESPProvision.Security
{
    public class Security0:ISecurity
    {
        private static string TAG = "Espressif::" + nameof(Security0);

        const int SESSION_STATE_0 = 0;
        const int SESSION_STATE_1 = 1;

        private int sessionState = SESSION_STATE_0;

        public byte[] GetNextRequestInSession(byte[] hexData)
        {
            byte[] response = null;
            switch (sessionState)
            {
                case SESSION_STATE_0:
                    this.sessionState = SESSION_STATE_1;
                    response = this.getStep0Request();
                    break;
                case SESSION_STATE_1:
                    this.processStep0Response(hexData);
                    break;
            }

            return response;
        }

        public byte[] Encrypt(byte[] data)
        {
            return data;
        }


        public byte[] Decrypt(byte[] data)
        {
            return data;
        }

        private byte[] getStep0Request()
        {
            Sec0Payload sec0Payload = new Sec0Payload()
            {
                Sc = new S0SessionCmd()
            };

            SessionData newSessionData = new SessionData
            {
                SecVer=0,
                Sec0= sec0Payload
            };

            return newSessionData.ToByteArray();
        }

        private void processStep0Response(byte[] hexData)
        {
            try {
                if (hexData == null)
                {
                    throw new Exception("No response from device");
                }
               
                SessionData responseData = SessionData.Parser.ParseFrom(hexData);
                if (responseData.SecVer != SecSchemeVersion.SecScheme0)
                {
                    throw new Exception("Security version mismatch");
                }
            }
            catch (InvalidProtocolBufferException e)
            {
            }
        }
    }
}
