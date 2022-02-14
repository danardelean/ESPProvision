using System;
using Shiny;
using Android.App;
using Android.Content;
using Android.Runtime;

namespace ESPProvision.Droid
{
	[global::Android.App.ApplicationAttribute]
	public partial class MainApplication : global::Android.App.Application
	{
		public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

		public override void OnCreate()
		{
			this.ShinyOnCreate(new ESPShinyStartup());
			global::Xamarin.Essentials.Platform.Init(this);
			base.OnCreate();
		}
	}
}
