using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartGardenMobile.Services;
using SmartGardenMobile.Views;
using System.IO;

namespace SmartGardenMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "deviceId.txt");
            File.Delete(fileName);
            if (File.Exists(fileName))
            {
                MainPage = new NavigationPage(new HomePage { Title = "Plant info" });
            }
            else
            {
                MainPage = new NavigationPage(new RegisterDevice { Title = "Register your device" });
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
