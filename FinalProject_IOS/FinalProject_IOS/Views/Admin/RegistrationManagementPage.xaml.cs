using FinalProject_IOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationManagementPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        public RegistrationManagementPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            FirebaseHelper f = new FirebaseHelper();

            var usersPending = await f.GetAllUsersPending();
            usersPending.Where(u => u.userStatus != "Denied");

            usersPendingListView.ItemsSource = null;
            usersPendingListView.ItemsSource = usersPending;
        }

        private async void Deny_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Deny Access", "Do you want to remove this user from the pending registrations?", "Yes", "No");
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            if (response)
            {
                //var user = await f.GetByID(sID);
                bool isDenied = await f.Deny(sID);
                if (isDenied)
                {
                    await DisplayAlert("Info", "user is removed", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }

        }

        private async void Accept_Tapped(object sender, EventArgs e)
        {
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            if (true)
            {
                //var user = await f.GetByID(sID);
                bool isDenied = await f.Accept(sID);
                if (isDenied)
                {
                    await DisplayAlert("Info", "user is accepted", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }


        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }
    }
}