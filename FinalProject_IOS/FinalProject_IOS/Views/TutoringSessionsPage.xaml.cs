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
    public partial class TutoringSessionsPage : ContentPage
    {
        public TutoringSessionsPage()
        {
            InitializeComponent();
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutorAssignmentMenuPage());
        }
        /*
        private void AddTutoringSession_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutorAssignmentMenuPage());
        }
        */
    }
}