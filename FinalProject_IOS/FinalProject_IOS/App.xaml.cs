using FinalProject_IOS.Views;
using FinalProject_IOS.Views.Admin;
using FinalProject_IOS.Views.Teacher;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RegisterPage());
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
