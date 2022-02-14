using System;
namespace ESPProvision.Listeners
{
    public class SessionListener:ISessionListener
    {
        Action _onSessionEstablished;
        Action<Exception> _onSessionEstablishFailed;
        public SessionListener(Action onSessionEstablished, Action<Exception> onSessionEstablishFailed)
        {
            _onSessionEstablished = onSessionEstablished;
            _onSessionEstablishFailed = onSessionEstablishFailed;
        }
        public void OnSessionEstablished()
        {
            _onSessionEstablished?.Invoke();
        }
        public void OnSessionEstablishFailed(Exception e)
        {
            _onSessionEstablishFailed?.Invoke(e);
        }
    }
}
