using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Shiny;
using Android.Content;

namespace ESPProvision.Droid
{
    [Activity(Label = "ESPProvision", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public partial class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App());
        }

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);
			this.ShinyOnNewIntent(intent);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			this.ShinyOnActivityResult(requestCode, resultCode, data);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			this.ShinyOnRequestPermissionsResult(requestCode, permissions, grantResults);
			global::Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}
