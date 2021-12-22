using FinalProject_IOS.Models;
using FinalProject_IOS.Views.Admin.Tutor;
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
    public partial class TutorManagementPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();

        public TutorManagementPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            var allTutors = await f.GetAllUsers();

            tutorList.ItemsSource = null;
            tutorList.ItemsSource = allTutors.Where(u => u.role == "Tutor");
        }

        private async void SeeGrades_Tapped(object sender, EventArgs e)
        {
            string accountId = ((TappedEventArgs)e).Parameter.ToString();

            if (accountId == null)
            {
                await DisplayAlert("Warning", "Tutor not found", "OK");
            }
            else
            {
                await Navigation.PushAsync(new GradesDisplayPage(accountId));
            }

        }

        private async void DeleteTutor_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm Deletion", "Do you want to remove this tutor from the database?", "Yes", "No");
            string accountId = ((TappedEventArgs)e).Parameter.ToString();
            if (response)
            {

                bool success = await f.DeleteTutor(accountId);
                if (success)
                {
                    await DisplayAlert("Info", "Tutor was successfully removed", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }

        }

        private async void EditTutor_Tapped(object sender, EventArgs e)
        {
            string accountId = ((TappedEventArgs)e).Parameter.ToString();
            var tutor = await f.GetTutorById(accountId);
            
            if (accountId == null)
            {
                await DisplayAlert("Warning", "Tutor not found", "OK");
            }
            else
            {
                tutor.accountId = accountId;
                await Navigation.PushModalAsync(new TutorEditPage(tutor));
                OnAppearing();
            }

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }

        private void AddTutor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add_TutorPage());
        }
    }
}