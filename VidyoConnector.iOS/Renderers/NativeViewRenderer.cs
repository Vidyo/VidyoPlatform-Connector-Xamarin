using AVFoundation;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(VidyoConnector.Controls.NativeView), typeof(VidyoConnector.iOS.NativeViewRenderer))]

namespace VidyoConnector.iOS
{
    public class NativeViewRenderer : Xamarin.Forms.Platform.iOS.ViewRenderer<VidyoConnector.Controls.NativeView, UIView>
    {
        UIView _uiView;

        public NativeViewRenderer() { }

        protected override async void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<VidyoConnector.Controls.NativeView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Instantiate the native control and assign it to the Control property with
                // the SetNativeControl method
                _uiView = new UIView() { ContentMode = UIViewContentMode.ScaleToFill };
                SetNativeControl(_uiView);
            }

            if (e.NewElement != null)
            {
                // Configure the control and subscribe to event handlers
                e.NewElement.Handle = this.Control.Handle;
                await this.AuthorizeMediaUse();
            }
        }

        async System.Threading.Tasks.Task AuthorizeMediaUse()
        {
            var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

            if (authorizationStatus != AVAuthorizationStatus.Authorized)
            {
                await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
            }

            authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Audio);
            if (authorizationStatus != AVAuthorizationStatus.Authorized)
            {
                await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Audio);
            }
        }
    }
}
