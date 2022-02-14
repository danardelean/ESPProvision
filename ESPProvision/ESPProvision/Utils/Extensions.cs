using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ESPProvision.Utils
{
    public static class Extensions
    {
        public static IDisposable SubOnMainThread<T>(this IObservable<T> observable, Action<T> onAction) =>
            observable.Subscribe(x => MainThread.BeginInvokeOnMainThread(() => onAction(x)));

        public static IDisposable SubOnMainThread<T>(this IObservable<T> observable, Action<T> onAction, Action<Exception> onError) =>
            observable.Subscribe(x => MainThread.BeginInvokeOnMainThread(() => onAction(x)), onError);

        public static IDisposable SubOnMainThread<T>(this IObservable<T> observable, Action<T> onAction, Action<Exception> onError, Action onComplete) =>
            observable.Subscribe(
                x => MainThread.BeginInvokeOnMainThread(() => onAction(x)),
                onError,
                onComplete
            );


    }
}
