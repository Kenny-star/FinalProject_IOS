using FinalProject_IOS.Models;
using FinalProject_IOS.Views.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Tutor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorDashboardPage : ContentPage
    {
        User user1 = new User();
        public TutorDashboardPage(User user)
        {
            InitializeComponent();

            user1.accountId = user.accountId;
            user1.courseId = user.courseId;
            user1.userName = user.userName;
            user1.password = user.password;
            user1.firstName = user.firstName;
            user1.lastName = user.lastName;
            user1.email = user.email;
            user1.role = user.role;
        }

        public TutorDashboardPage() { InitializeComponent(); }

        private void AddSession_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddSession(user1));
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}