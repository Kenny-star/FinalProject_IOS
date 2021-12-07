using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_IOS.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        // Initialize Firebase helper class
        FirebaseHelper fbHelper = new FirebaseHelper();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            string accountId = Guid.NewGuid().ToString("N");
            string userName = username.Text;
            string pwd = password.Text;
            string firstName = firstname.Text;
            string lastName = lastname.Text;
            string emailAddr = email.Text;
            string courseName = course.Text;

            // Register tutor to DB
            if (Tutor.IsChecked) { 
                await fbHelper.registerTutor(accountId, firstName, lastName, emailAddr, courseName, userName, pwd, "0");
                await DisplayAlert("Account created", "Tutor account successfully created", "OK");
            }

            // Register teacher to DB
            if (Teacher.IsChecked) {
                await fbHelper.registerTeacher(accountId, firstName, lastName, emailAddr, courseName, userName, pwd);
                await DisplayAlert("Account created", "Teacher account successfully created", "OK");
            }

            // Register student to DB
            if (Tutee.IsChecked) {
                await fbHelper.registerStudent(accountId, firstName, lastName, emailAddr, courseName, userName, pwd, "0");
                await DisplayAlert("Account created", "Student account successfully created", "OK");
            }

        }
    }
}                                              