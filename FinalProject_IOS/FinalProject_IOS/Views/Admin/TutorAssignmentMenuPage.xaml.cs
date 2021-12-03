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
    public partial class TutorAssignmentMenuPage : ContentPage
    {
        public TutorAssignmentMenuPage()
        {
            InitializeComponent();
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssignTutorsPage());
        }

        private void AddTutor_Clicked(object sender, EventArgs e)
        {
            //Insert to db
        }

        private void ViewTutoringHours_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutoringSessionsPage());
        }
    }
}