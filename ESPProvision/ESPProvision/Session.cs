using System;
using ESPProvision.Listeners;
using ESPProvision.Security;
using ESPProvision.Transport;

namespace ESPProvision
{
    public class Session 
    {
        private const string TAG = "Espressif::" + nameof(Session);
        private ITransport transport;
        private ISecurity security;
        private bool isSessionEstablished;
        /**
         * Initialize Session object with Transport and Security interface implementations
         *
         * @param transport
         * @param security
         */
        public Session(ITransport transport, ISecurity security)
        {
            this.transport = transport;
            this.security = security;
        }

        /**
         * Get the Security implementation object
         *
         * @return
         */
        public ISecurity Security
        {
            get => security;
        }

        /**
         * Get the Transport implementation object.
         *
         * @return
         */
        public ITransport Transport
        {
            get => transport;
        }

        /**
         * Get whether a secure Session has been established.
         *
         * @return
         */
        public bool IsSessionEstablished
        {
            get => isSessionEstablished;
        }

        public void Init(byte[] response, ISessionListener sessionListener) 
        {
            try
            {
                byte[] request = security.GetNextRequestInSession(response);

                if (request == null)
                {
                    isSessionEstablished = true;
                    if (sessionListener != null)
                        sessionListener.OnSessionEstablished();
                }
                else
                    transport.SendConfigData(
                        ESPConstants.HANDLER_PROV_SESSION,
                        request,
                        new ResponseListener(
                            onSuccess:(byte[] returnData)=>
                            {
                                if (returnData == null)
                                    sessionListener?.OnSessionEstablishFailed(new Exception("Session could not be established"));
                                else
                                    Init(returnData, sessionListener);
                            },onFailure:(Exception e)=>
                            {
                                sessionListener?.OnSessionEstablishFailed(e);
                            }));
            }
            catch (Exception e)
            {
                if (response == null)
                    sessionListener?.OnSessionEstablishFailed(new Exception("Session could not be established"));
            }
        }

        public void SendDataToDevice(string path, byte[] data, IResponseListener listener)
        {
            byte[] encryptedData = security.Encrypt(data);
            if (isSessionEstablished)
            {
                transport.SendConfigData(path, encryptedData, new ResponseListener(
                            onSuccess: (byte[] returnData) =>
                            {
                                byte[] decryptedData = security.Decrypt(returnData);
                                listener?.OnSuccess(decryptedData);
                            }, onFailure: (Exception e) =>
                            {
                                isSessionEstablished = false;
                                listener?.OnFailure(e);
                            }));
            }
            else
            {
                Init(null, new SessionListener(
                            onSessionEstablished: () =>
                            {
                                transport.SendConfigData(path, encryptedData, new ResponseListener(
                                    onSuccess: (byte[] returnData) =>
                                    {
                                        listener?.OnSuccess(returnData);
                                    },
                                    onFailure: (Exception e) =>
                                    {
                                        listener?.OnFailure(e);
                                    }));
                            }, onSessionEstablishFailed: (Exception e) =>
                            {
                                listener?.OnFailure(e);
                            }));
            }
        }
    }
}
