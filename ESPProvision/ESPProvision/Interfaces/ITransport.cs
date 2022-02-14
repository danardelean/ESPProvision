using System;
using System.Threading.Tasks;
using ESPProvision;

namespace ESPProvision.Transport
{
    public interface ITransport
    {
        /***
         * Send data relating to device configurations
         * @param path path of the config endpoint.
         * @param data config data to be sent
         * * @param listener listener implementation which receives events when response is received.
         */
        void SendConfigData(String path, byte[] data, IResponseListener listener);
    }
}
