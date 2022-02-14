using System;
namespace ESPProvision.Listeners
{
    public class ResponseListener : IResponseListener
    {
        Action<byte[]> _onSuccess;
        Action<Exception> _onFailure;
        public ResponseListener(Action<byte[]> onSuccess, Action<Exception> onFailure)
        {
            _onSuccess = onSuccess;
            _onFailure = onFailure;
        }
        public void OnFailure(Exception e)
        {
            _onFailure?.Invoke(e);
        }
        public void OnSuccess(byte[] returnData)
        {
            _onSuccess?.Invoke(returnData);
        }
    }
}
