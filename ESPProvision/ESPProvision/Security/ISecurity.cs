using System;
namespace ESPProvision.Security
{
    public interface ISecurity
    {
        /**
   * Get the next request based upon the current Session
   * state and the response data passed to this function
   * @param responseData
   * @return
   */
        byte[] GetNextRequestInSession(byte[] responseData);

        /**
         * Encrypt the data according to the Security implementation
         * @param data
         * @return
         */
        byte[] Encrypt(byte[] data);

        /**
         * Decrypt data according to the Security implementation
         * @param data
         * @return
         */
        byte[] Decrypt(byte[] data);
    }
}
