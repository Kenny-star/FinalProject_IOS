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

        private void MangageRegistrations_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationManagementPage());
        }

        private void AssignTutors_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new AssignTutorsPage());
        }
    }
}