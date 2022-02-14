using System;
namespace ESPProvision
{
    public interface IResponseListener
    {
        /***
     * Successfully sent and received response from device
     * @param returnData
     */
        void OnSuccess(byte[] returnData);

        /***
         * Failed to send data or receive response from device
         * @param e
         */
        void OnFailure(Exception e);
    }
}
