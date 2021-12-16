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
    public partial class StudentManagementPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();

        public StudentManagementPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            var allStudents = await f.GetAllUsers();

            studentList.ItemsSource = null;
            studentList.ItemsSource = allStudents.Where(u => u.role == "Tutee");
        }

        private async void DeleteStudent_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm Deletion", "Do you want to remove this student from the database?", "Yes", "No");
            string accountId = ((TappedEventArgs)e).Parameter.ToString();
            if (response)
            {

                bool success = await f.DeleteStudent(accountId);
                if (success)
                {
                    await DisplayAlert("Info", "Student was successfully removed", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }

        }

        private async void EditStudent_Tapped(object sender, EventArgs e)
        {
            string accountId = ((TappedEventArgs)e).Parameter.ToString();
            var student = await f.GetStudentById(accountId);
            
            if (accountId == null)
            {
                await DisplayAlert("Warning", "Student not found", "OK");
            }
            else
            {
                student.accountId = accountId;
                await Navigation.PushModalAsync(new StudentEditPage(student));
                OnAppearing();
            }

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }

        private void AddStudent_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add_StudentPage());
        }
    }
}