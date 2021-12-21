using FinalProject_IOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorListAvailabilitiesPage : ContentPage
    {
        User user1 = new User();
        FirebaseHelper f = new FirebaseHelper();
        public TutorListAvailabilitiesPage(User user)
        {
            InitializeComponent();
            user1.accountId = user.accountId;
            user1.courseId = user.courseId;
            user1.firstName = user.firstName;
            user1.lastName = user.lastName;
            user1.role = user.role;
        }

        protected override async void OnAppearing()
        {

            var tutoringAvailabilities = await f.GetAllTutoringOffers();

            tutorsListView.ItemsSource = null;
            tutorsListView.ItemsSource = tutoringAvailabilities;
        }

        private async void JoinTutoringSession_Clicked(object sender, EventArgs e)
        {
            string tutoringId = ((TappedEventArgs)e).Parameter.ToString();

            var tutoringSession = await f.GetByTutoringSessionById(tutoringId);
            await Navigation.PushAsync(new ManageAccessPage(user1,tutoringSession));
        }

        private void Report_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReportTutorFromTuteePage());
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TuteeDashboardPage(user1));
        }

    }
}