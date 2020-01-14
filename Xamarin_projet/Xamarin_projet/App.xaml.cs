using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_projet
{
    public partial class App : Application
    {
        public static MessageManager MessageManager { get; private set; }
        public App()
        {
            InitializeComponent();
            MessageManager = new MessageManager(new RestService());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
