using System;
using Xamarin.Forms;

namespace VidyoConnector.Controls
{
    public class NativeView : View
    {
        public Command OnHandleSet { get; set; }

        private IntPtr handle;

        public IntPtr Handle {

            get {
                return handle;
            }

            set {
                handle = value;
                OnHandleSet?.Execute(value);
            }
        }

        public float  Density { get; set; }

        public uint NativeWidth  { get { return (uint)(Width * Density); } }
        public uint NativeHeight { get { return (uint)(Height * Density); } }

        public NativeView() { Density = 1.0F; }
    }
}