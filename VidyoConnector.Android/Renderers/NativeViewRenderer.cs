using Android.App;
using Android.Util;
using Android.Widget;

[assembly: Xamarin.Forms.ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.Android.NativeViewRenderer))]

namespace VidyoConnector.Android
{
    public class NativeViewRenderer : Xamarin.Forms.Platform.Android.ViewRenderer<VidyoConnector.Controls.NativeView, FrameLayout>
    {
        FrameLayout _frameLayout;

        public NativeViewRenderer() { }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<VidyoConnector.Controls.NativeView> e)
        {
            base.OnElementChanged(e);

            if (Control == null) {
                // Instantiate the native control and assign it to the Control property with
                // the SetNativeControl method
                _frameLayout = new FrameLayout(this.Context);
                SetNativeControl(_frameLayout);
            }

            if (e.NewElement != null) {
                // Configure the control and subscribe to event handlers

// For some reason, when DisplayMetrics is referenced, the UI preview in MainPage.xaml.cs is not shown.
// Set #if to false if you want to see a valid preview of the UI.
#if true
                DisplayMetrics displayMetrics = Application.Context.Resources.DisplayMetrics;
                e.NewElement.Density = displayMetrics.Density;
#endif
                e.NewElement.Handle  = this.Control.Handle;
            }
        }
    }
}
