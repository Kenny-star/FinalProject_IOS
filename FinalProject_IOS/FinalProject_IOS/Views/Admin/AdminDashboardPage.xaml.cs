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
    public partial class AdminDashboardPage : ContentPage
    {
        public AdminDashboardPage()
        {
            InitializeComponent();
        }

        private void ManageCourses_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseManagementPage());
        }

        private void ManageRegistrations_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationManagementPage());
        }

        private void AssignTutors_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssignTutorsPage());
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}