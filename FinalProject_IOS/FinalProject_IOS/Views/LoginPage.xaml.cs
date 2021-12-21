using FinalProject_IOS.Models;
using FinalProject_IOS.Views.Admin;
using FinalProject_IOS.Views.Student;
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
            string adminUsername = "myadmin";
            string adminPassword = "MyStrongPassword!";

            FirebaseHelper f = new FirebaseHelper();

            AuthHelper auth = new AuthHelper();

            List<User> Users = await f.GetAllUsers();


            if ((username.Text.ToLower()) == adminUsername && password.Text == adminPassword)
            {
                await Navigation.PushAsync(new AdminDashboardPage());

            }

            else
            {
                foreach (User user in Users)
                {

                    if ((username.Text.ToLower()) == (user.userName.ToLower()) && (auth.hashPassword(password.Text)) == user.password)
                    {

                        if (user.role == "Tutor" && user.userStatus == "Accepted")
                        {
                            notFound = false;
                            await Navigation.PushAsync(new TutorDashboardPage(user));
                            break;
                        }


                        if (user.role == "Teacher" && user.userStatus == "Accepted")
                        {
                            notFound = false;
                            await Navigation.PushAsync(new TeacherDashboardPage());
                            break;
                        }

                        if (user.role == "Tutee" && user.userStatus == "Accepted")
                        {
                            notFound = false;
                            await Navigation.PushAsync(new TuteeDashboardPage(user));
                            break;
                        }

                        if (user.userStatus == "Pending")
                        {
                            notFound = false;
                            await Navigation.PushAsync(new RegistrationPending());
                            break;
                        }

                        if (user.userStatus == "Denied")
                        {
                            notFound = false;
                            await Navigation.PushAsync(new RegistrationDeniedPage());
                            break;
                        }
                    }

                    else
                    {
                        notFound = true;
                    }
                    
                }

                if (notFound)
                {
                    await DisplayAlert("Error!", "Incorrect Username or Password", "OK");
                }
            }
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}