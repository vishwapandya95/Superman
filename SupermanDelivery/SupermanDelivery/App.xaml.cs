using SupermanDelivery.Services;
using SupermanDelivery.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupermanDelivery
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // DependencyService.Register<MockDataStore>();
            MainPage = new FlyoutPage1();
            //MainPage = new NavigationPage(new UploadDocumentsPage());
             
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
