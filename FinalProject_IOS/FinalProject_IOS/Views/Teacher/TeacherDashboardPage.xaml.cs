using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Teacher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherDashboardPage : ContentPage
    {
        public TeacherDashboardPage()
        {
            InitializeComponent();
        }

        private void MonitorSessions_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SessionListforTeachers());
        }

        private void MonitorStudents_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TuteeListPage());
        }

        private void ManageRegistrations_Clicked(object sender, EventArgs e)
        {

        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}