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
    public partial class TeacherManagementPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();

        public TeacherManagementPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            var allUsers = await f.GetAllUsers();

            teachersListView.ItemsSource = null;
            teachersListView.ItemsSource = allUsers.Where(u => u.role == "Teacher");
        }

        private async void DeleteTeacher_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm Deletion", "Do you want to remove this teacher from the database?", "Yes", "No");
            string accountId = ((TappedEventArgs)e).Parameter.ToString();
            if (response)
            {

                bool success = await f.DeleteTeacher(accountId);
                if (success)
                {
                    await DisplayAlert("Info", "Teacher was successfully removed", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }

        }

        private async void EditTeacher_Tapped(object sender, EventArgs e)
        {
            string accountId = ((TappedEventArgs)e).Parameter.ToString();
            var teacher = await f.GetTeacherById(accountId);
            
            if (accountId == null)
            {
                await DisplayAlert("Warning", "Teacher not found", "OK");
            }
            else
            {
                teacher.accountId = accountId;
                await Navigation.PushModalAsync(new TeacherEditPage(teacher));
                OnAppearing();
            }

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }

        private void AddTeacher_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add_TeacherPage());
        }
    }
}