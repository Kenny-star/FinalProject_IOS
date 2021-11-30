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
    public partial class AdminDashboard : ContentPage
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void manageCourses_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new CourseManagement());
        }

        private void mangageRegistrations_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new RegistrationManagementAdmin());
        }

        private void assignTutors_Clicked(object sender, EventArgs e)
        {
           // Navigation.PushAsync(new AssignTutors());
        }
    }
}