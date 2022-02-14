using System;
namespace ESPProvision
{
    public interface IProvisionListener
    {
        /**
     * Called when session creation is failed.
     *
     * @param e Exception
     */
        void CreateSessionFailed(Exception e);

        /**
         * Called when Wi-Fi credentials successfully sent to the device.
         */
        void WifiConfigSent();

        /**
         * Called when Wi-Fi credentials failed to send to the device.
         *
         * @param e Exception
         */
        void WifiConfigFailed(Exception e);

        /**
         * Called when Wi-Fi credentials successfully applied to the device.
         */
        void WifiConfigApplied();

        /**
         * Called when Wi-Fi credentials failed to apply to the device.
         *
         * @param e Exception
         */
        void WifiConfigApplyFailed(Exception e);

        /**
         * Callback for giving provision status update.
         *
         * @param failureReason Failure reason received form device.
         */
        void ProvisioningFailedFromDevice(ProvisionFailureReason failureReason);

        /**
         * Called when device is provisioned successfully.
         */
        void DeviceProvisioningSuccess();

        /**
         * Called when provisioning is failed.
         *
         * @param e Exception
         */
        void OnProvisioningFailed(Exception e);
    }
}
