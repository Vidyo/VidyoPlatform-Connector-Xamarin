using System;
using Xamarin.Forms;

namespace VidyoConnector
{
    public interface IVidyoController
    {
        bool Initialize();
        // Create connector instance and return client version
        String Construct(Controls.NativeView videoView);

        void ReleaseDevices();

        // Page high-level lifecycle events
        void OnAppResume();
        void OnAppSleep();

        // Fetch connector state
        VidyoConnectorState ConnectorState { get; set; }

        // Events triggered by button clicks from UI
        bool Connect(string portal, string roomKey, string displayName, string pin);
        void Disconnect();

        // Orientation has changed or new UI size allocated
        void RefreshUI();

        void SetCameraPrivacy(bool privacy);
        void SetMicrophonePrivacy(bool privacy);

        void CycleCamera();

        void EnableDebugging();
        void DisableDebugging();
    }
}