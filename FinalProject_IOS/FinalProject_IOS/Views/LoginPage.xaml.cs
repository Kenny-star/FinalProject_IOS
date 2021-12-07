using FinalProject_IOS.Models;
using FinalProject_IOS.Views.Admin;
using FinalProject_IOS.Views.Teacher;
using FinalProject_IOS.Views.Tutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            bool notFound = true;
            string adminUsername = "MyAdmin";
            string adminPassword = "MyStrongPassword!";

            FirebaseHelper util = new FirebaseHelper();

            List<User> pendingUsers = await util.GetAllUsersPending();

            

            if (username.Text == adminUsername && password.Text == adminPassword)
            {
                notFound = false;
                await Navigation.PushAsync(new AdminDashboardPage());

            }

            else
            {

                foreach (User user in pendingUsers)
                {


                    if (username.Text == user.userName && password.Text == user.password)
                    {

                        if (user.role == "Tutor" && user.userStatus == "Accepted")
                        {
                            notFound = false;
                            await Navigation.PushAsync(new TutorDashboardPage());
                            break;
                        }


                        if (user.role == "Teacher" && user.userStatus == "Accepted")
                        {
                            notFound = false;
                            await Navigation.PushAsync(new TeacherDashboardPage());
                            break;
                        }

                        if (user.userStatus == "Pending")
                        {
                            await Navigation.PushAsync(new RegistrationPending());
                            break;
                        }

                        if (user.userStatus == "Denied")
                        {
                            await Navigation.PushAsync(new RegistrationDeniedPage());
                            break;
                        }
                    }
                    else if ((pendingUsers.Count == 0 && username.Text != adminUsername && password.Text != adminPassword) || notFound)
                    {
                        await DisplayAlert("Error!", "Incorrect Username or Password", "OK");
                    }

                }
            }
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}