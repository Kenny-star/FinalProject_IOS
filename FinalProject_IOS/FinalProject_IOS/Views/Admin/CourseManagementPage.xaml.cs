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
    public partial class CourseManagementPage : ContentPage
    {
        public CourseManagementPage()
        {
            InitializeComponent();
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }

        private void Add_Course_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add_CoursePage());
        }
    }
}