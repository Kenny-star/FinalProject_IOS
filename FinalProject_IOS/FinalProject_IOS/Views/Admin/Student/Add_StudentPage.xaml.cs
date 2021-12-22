using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_IOS.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_StudentPage : ContentPage
    {
        // Initialize Firebase helper class
        FirebaseHelper fbHelper = new FirebaseHelper();

        public Add_StudentPage()
        {
            InitializeComponent();
        }


        // Add course
        private async void AddStudent_Clicked(object sender, EventArgs e)
        {
            string accountId = Guid.NewGuid().ToString("N");
            string FirstName = firstName.Text;
            string LastName = lastName.Text;
            string emailAddress = email.Text;
            string uname = username.Text;
            string pwd = password.Text;
            string courseId = courseid.Text;


            bool success = await fbHelper.AddStudent(accountId, courseId, uname, pwd, FirstName, LastName, emailAddress);

            if (success)
            {
                await DisplayAlert("Notice", "Student has been successfully added!", "OK");
                await Navigation .PushAsync(new StudentManagementPage());
            }

            else
            {
                await DisplayAlert("Error", "Failed to add new student!", "OK");
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentManagementPage());
        }
    }
}