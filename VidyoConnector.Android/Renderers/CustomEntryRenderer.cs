using Android.Graphics;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(VidyoConnector.Android.CustomEntryRenderer))]

namespace VidyoConnector.Android
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            // Hides the underlined text in the Xamarin.Forms.Entry UI item
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Color.Transparent);
            if (Control != null)
            {
                Control.SetPadding(10, 30, 10, 0);
            }
        }
    }
}
