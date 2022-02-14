using System;
namespace ESPProvision
{
    public interface ISessionListener
    {
        /**
       * Called when session is established.
       * Further communication with the device can only
       * occur after this callback is called.
       */
        void OnSessionEstablished();

        /**
         * Called when session establish fails.
         *
         * @param e Exception
         */
        void OnSessionEstablishFailed(Exception e);
    }
}
