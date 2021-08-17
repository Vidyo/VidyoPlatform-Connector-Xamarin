using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace VidyoConnector.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions) {
            global::Xamarin.Forms.Forms.Init();
            try {
                LoadApplication(new App(VidyoController.GetInstance()));
            } catch (Exception e) {
                Logger.GetInstance().Log(e.Message);
            }

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override void WillEnterForeground(UIApplication application)
        {
            base.WillEnterForeground(application);
        }
    }
}