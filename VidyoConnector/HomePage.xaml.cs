using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VidyoConnector
{
    public partial class HomePage : ContentPage
    {

        private IVidyoController mVidyoController;

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(IVidyoController vidyoController)
        {
            InitializeComponent();
            this.mVidyoController = vidyoController;
        }

        async void OnStartConference(object sender, EventArgs args)
        {
            VideoPage compositeLayoutPage = new VideoPage();
            compositeLayoutPage.Initialize(this.mVidyoController);

            await Navigation.PushModalAsync(compositeLayoutPage);
        }
    }
}