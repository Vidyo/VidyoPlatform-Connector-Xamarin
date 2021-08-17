using System;
using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.OS;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;

namespace VidyoConnector.Android
{
    [Activity(Label = "VidyoConnector Xamarin Android",
    Icon = "@drawable/vidyo_io_icon",
    Theme = "@style/MyTheme",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        private static int PERMISSION_REQUEST_FALLBACK = 34;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ChecPermissions();

            try
            {
                LoadApplication(new App(VidyoController.GetInstance()));
            }
            catch (Exception e)
            {
                Logger.GetInstance().Log(e.Message);
            }
        }

        private void ChecPermissions()
        {
            if (hasPermissionsGranted())
            {
                Logger.GetInstance().Log("All permissions are granted!");
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera, Manifest.Permission.RecordAudio }, PERMISSION_REQUEST_FALLBACK);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == PERMISSION_REQUEST_FALLBACK)
            {
                Logger.GetInstance().Log("Received response for Camera/Audio permission request.");

                if (hasPermissionsGranted())
                {
                    Logger.GetInstance().Log("All permissions are granted!");
                }
                else
                {
                    Logger.GetInstance().Log("All permissions are NOT granted!");
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        private bool hasPermissionsGranted()
        {
            return ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) == (int)Permission.Granted
                && ContextCompat.CheckSelfPermission(this, Manifest.Permission.RecordAudio) == (int)Permission.Granted;
        }
    }
}