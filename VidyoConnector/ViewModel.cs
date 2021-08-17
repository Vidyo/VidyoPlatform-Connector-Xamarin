﻿using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace VidyoConnector
{
    public class ViewModel : INotifyPropertyChanged
    {
        private static ViewModel _instance = new ViewModel();
        public static ViewModel GetInstance() { return _instance; }

        private ViewModel()
        {
            this.DisplayDiagnostics = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        const string _ready = "Ready to Connect";

        const string _cameraOnImage = "camera_on.png";
        const string _cameraOffImage = "camera_off.png";
        const string _microphoneOnImage = "microphone_on.png";
        const string _microphoneOffImage = "microphone_off.png";
        const string _callStartImage = "call_start.png";
        const string _callEndImage = "call_end.png";
        const string _gearIMage = "gear.png";

        string _cameraPrivacyImage = _cameraOnImage;
        string _microphonePrivacyImage = _microphoneOnImage;
        string _callImage = _callStartImage;

        bool _cameraPrivacy = false;
        bool _microphonePrivacy = false;

        string _toolbarStatus = _ready;
        string _clientVersion = "v 0.0.00.x";

        string _portal = "*.platform.vidyo.io"; // Insert valid Portal FQDN e.g.: *.platform.vidyo.io
        string _roomKey = ""; // Insert valid RoomKey e.g.: 8huaP05z6Z
        string _displayName = "Xamarin User"; // Insert your Display Name
        string _roomPin = ""; // Insert valid roomPin e.g.: Res$!dfs45

        VidyoCallAction _callAction = VidyoCallAction.VidyoCallActionConnect;

        public void Refresh()
        {
            _cameraPrivacy = false;
            _microphonePrivacy = false;

            _cameraPrivacyImage = _cameraOnImage;
            _microphonePrivacyImage = _microphoneOnImage;

            _callAction = VidyoCallAction.VidyoCallActionConnect;
            _callImage = _callStartImage;
            _toolbarStatus = _ready;
        }

        public bool ToggleCameraPrivacy()
        {
            _cameraPrivacy = !_cameraPrivacy;
            CameraPrivacyImage = _cameraPrivacy ? _cameraOffImage : _cameraOnImage;
            return _cameraPrivacy;
        }

        public bool ToggleMicrophonePrivacy()
        {
            _microphonePrivacy = !_microphonePrivacy;
            MicrophonePrivacyImage = _microphonePrivacy ? _microphoneOffImage : _microphoneOnImage;
            return _microphonePrivacy;
        }

        public VidyoCallAction ToggleCallAction()
        {
            CallAction = _callAction == VidyoCallAction.VidyoCallActionConnect ?
                          VidyoCallAction.VidyoCallActionDisconnect : VidyoCallAction.VidyoCallActionConnect;
            return _callAction;
        }

        public VidyoCallAction CallAction
        {
            set
            {
                _callAction = value;
                CallImage = _callAction == VidyoCallAction.VidyoCallActionConnect ? _callStartImage : _callEndImage;
            }
            get { return _callAction; }
        }

        public string Portal
        {
            get { return _portal; }
            set
            {
                if (_portal != value)
                {
                    _portal = value;
                    OnPropertyChanged("Portal");
                }
            }
        }

        public string RoomKey
        {
            get { return _roomKey; }
            set
            {
                if (_roomKey != value)
                {
                    _roomKey = value;
                    OnPropertyChanged("RoomKey");
                }
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged("DisplayName");
                }
            }
        }

        public string RoomPin
        {
            get { return _roomPin; }
            set
            {
                if (_roomPin != value)
                {
                    _roomPin = value;
                    OnPropertyChanged("RoomPin");
                }
            }
        }

        public string ToolbarStatus
        {
            get { return _toolbarStatus; }
            set
            {
                if (_toolbarStatus != value)
                {
                    _toolbarStatus = value;
                    OnPropertyChanged("ToolbarStatus");
                }
            }
        }

        public string ClientVersion
        {
            get { return _clientVersion; }
            set
            {
                if (_clientVersion != value)
                {
                    _clientVersion = value;
                    OnPropertyChanged("ClientVersion");
                }
            }
        }

        public string CallImage
        {
            get { return _callImage; }
            set
            {
                if (_callImage != value)
                {
                    _callImage = value;
                    OnPropertyChanged("CallImage");
                }
            }
        }

        public string CameraPrivacyImage
        {
            get { return _cameraPrivacyImage; }
            set
            {
                if (_cameraPrivacyImage != value)
                {
                    _cameraPrivacyImage = value;
                    OnPropertyChanged("CameraPrivacyImage");
                }
            }
        }

        public bool DisplayDiagnostics { get; set; }

        public string MicrophonePrivacyImage
        {
            get { return _microphonePrivacyImage; }
            set
            {
                if (_microphonePrivacyImage != value)
                {
                    _microphonePrivacyImage = value;
                    OnPropertyChanged("MicrophonePrivacyImage");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
