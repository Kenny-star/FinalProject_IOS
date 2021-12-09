using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string errorMessagePrompt = "ERROR! Please fill in the following inputs:\n\n";

            if (username.Text == null || username.Text == "")
            {
                errorMessagePrompt += "- Enter a valid username -\n";
            }
            if (password.Text == null || password.Text == "")
            {
                errorMessagePrompt += "- Enter a valid password -\n";
            }
            if (password.Text != null && password.Text != "")
            {
                if (password.Text.Length <= 10)
                {
                    errorMessagePrompt += "- Enter a valid password: Need more than 10 characters -\n";
                }
            }
            if (firstname.Text == null || firstname.Text == "")
            {
                errorMessagePrompt += "- Enter a valid first name -\n";
            }
            if (lastname.Text == null || lastname.Text == "")
            {
                errorMessagePrompt += "- Enter a valid last name -\n";
            }

            if (email.Text == null || email.Text == "")
            {
                errorMessagePrompt += "- Enter a valid email -";
            }

            if (!Tutor.IsChecked && !Tutee.IsChecked && !Teacher.IsChecked)
            {
                errorMessagePrompt += "\n- Enter a valid role -";
            }

            if (email.Text != null && !Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorMessagePrompt += "- Enter a valid email -";
            }
            if (errorMessagePrompt != "ERROR! Please fill in the following inputs:\n\n")
            {
                await DisplayAlert("Alert", errorMessagePrompt, "OK");
            }

            if (errorMessagePrompt == "ERROR! Please fill in the following inputs:\n\n")
            {


                string accountId = Guid.NewGuid().ToString("N");
                string userName = username.Text;
                string pwd = password.Text;
                string firstName = firstname.Text;
                string lastName = lastname.Text;
                string emailAddr = email.Text;
                string courseName = course.Text;

                // Register tutor to DB
                if (Tutor.IsChecked)
                {
                    string role = "Tutor";
                    await fbHelper.AddUserToPendingList(accountId, courseName, userName, pwd, firstName, lastName, emailAddr, role, "Pending");
                    await DisplayAlert("Account created", "Tutor account successfully created", "OK");

                    await Navigation.PushAsync(new LoginPage());
                }
                if (Teacher.IsChecked)
                {
                    string role = "Teacher";
                    await fbHelper.AddUserToPendingList(accountId, courseName, userName, pwd, firstName, lastName, emailAddr, role, "Pending");
                    await DisplayAlert("Account created", "Teacher account successfully created", "OK");

                    await Navigation.PushAsync(new LoginPage());
                }
                if (Tutee.IsChecked)
                {
                    string role = "Tutee";
                    await fbHelper.AddUserToPendingList(accountId, courseName, userName, pwd, firstName, lastName, emailAddr, role, "Pending");
                    await DisplayAlert("Account created", "Tutee account successfully created", "OK");

                    await Navigation.PushAsync(new LoginPage());
                }
            }
        }
    }
}                                              