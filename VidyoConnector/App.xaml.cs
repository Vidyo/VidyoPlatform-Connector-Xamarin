using System.Diagnostics;
using Xamarin.Forms;

namespace VidyoConnector
{
    public partial class App : Application
    {
        private IVidyoController mVidyoController = null;

        /* Need this in order to see preview in App.xaml interface builder */
        public App()
        {
            InitializeComponent();
            MainPage = new HomePage();
        }

        public App(IVidyoController vidyoController)
        {
            InitializeComponent();
            this.mVidyoController = vidyoController;

            HomePage homePage = new HomePage(vidyoController);
            MainPage = new NavigationPage(homePage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("OnSleep");
            mVidyoController.OnAppSleep();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Debug.WriteLine("OnResume");
            mVidyoController.OnAppResume();
        }
    }
}