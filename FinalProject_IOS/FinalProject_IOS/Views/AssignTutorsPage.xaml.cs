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
    public partial class AssignTutorsPage : ContentPage
    {
        public AssignTutorsPage()
        {//Should have a mvvm or and Onclick to pass object to new navigation.
            InitializeComponent();
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }

        private void AssignTutor_Clicked(object sender, EventArgs e)
        {
            //Should have a mvvm or and Onclick to pass object to new navigation.
            Navigation.PushAsync(new TutorAssignmentMenuPage());
        }

        private void ViewTutor_Clicked(object sender, EventArgs e)
        {
            //Should have a mvvm or and Onclick to pass object to new navigation.
            Navigation.PushAsync(new StudentsListPage());
        }
    }
}