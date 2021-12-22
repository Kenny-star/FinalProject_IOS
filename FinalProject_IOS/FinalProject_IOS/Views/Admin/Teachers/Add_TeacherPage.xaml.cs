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
    public partial class Add_TeacherPage : ContentPage
    {
        // Initialize Firebase helper class
        FirebaseHelper fbHelper = new FirebaseHelper();

        public Add_TeacherPage()
        {
            InitializeComponent();
        }


        // Add course
        private async void AddTeacher_Clicked(object sender, EventArgs e)
        {
            string accountId = Guid.NewGuid().ToString("N");
            string FirstName = firstName.Text;
            string LastName = lastName.Text;
            string emailAddress = email.Text;
            string uname = username.Text;
            string pwd = password.Text;
            string courseId = courseid.Text;


            bool success = await fbHelper.AddTeacher(accountId, courseId, uname, pwd, FirstName, LastName, emailAddress);

            if (success)
            {
                await DisplayAlert("Notice", "Teacher has been successfully added!", "OK");
                await Navigation .PushAsync(new TeacherManagementPage());
            }

            else
            {
                await DisplayAlert("Error", "Failed to add new teacher!", "OK");
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeacherManagementPage());
        }
    }
}