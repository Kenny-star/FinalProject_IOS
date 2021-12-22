using FinalProject_IOS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageAccessPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        User user1 = new User();
        Tutoring tutoringSession1 = new Tutoring();
        public ManageAccessPage(User user, Tutoring tutoringSession)
        {
            InitializeComponent();
            user1.accountId = user.accountId;
            user1.courseId = user.courseId;
            user1.firstName = user.firstName;
            user1.email = user.email;
            user1.lastName = user.lastName;
            user1.role = user.role;

            tutoringSession1.tutoringId = tutoringSession.tutoringId;
            tutoringSession1.tutorId = tutoringSession.tutorId;
            tutoringSession1.startTime = tutoringSession.startTime;
            tutoringSession1.endTime = tutoringSession.endTime;
            tutoringSession1.date = tutoringSession.date;
            tutoringSession1.firstName = tutoringSession.firstName;
            tutoringSession1.lasttName = tutoringSession.lasttName;
        }

        protected override void OnAppearing()
        {
            ObservableCollection<Tutoring> target = new ObservableCollection<Tutoring>();

            JoinTutoringSessionFormListView.ItemsSource = null;
            JoinTutoringSessionFormListView.ItemsSource = target;

            target.Add(new Tutoring { tutoringId = tutoringSession1.tutoringId, tutorId = tutoringSession1.tutorId, firstName = tutoringSession1.firstName, lasttName = tutoringSession1.lasttName });

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutorListAvailabilitiesPage(user1));
        }

        private async void JoinTutoringSession_Clicked(object sender, EventArgs e)
        {
            string tutoringId = tutoringSession1.tutoringId;
            string accountId = user1.accountId;
            string firstName = user1.firstName;
            string lasttName = user1.lastName;
            string email = user1.email;
            string availability = tutoringSession1.date;
            string start = tutoringSession1.startTime;
            string end = tutoringSession1.endTime;

            DateTime dtFrom = DateTime.Parse(start);
            DateTime dtTo = DateTime.Parse(end);

            double timeDiff = dtTo.Hour - dtFrom.Hour;

            bool response = await f.JoinTutoringSession(tutoringId, accountId, firstName, lasttName, availability, start, end, timeDiff);



            if (response)
            {
                await DisplayAlert("Notice", "You have successfully schedule your tutoring session!", "OK");

                await Navigation.PushAsync(new TuteeDashboardPage(user1));
            }

            else
            {
                await DisplayAlert("Error", "An error occured while inserting!", "OK");
            }
        }

        private async void CancelTutoringSession_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm Deletion", "Do you want to remove this tutoring posting from the list?", "Yes", "No");

            string tutoringId = tutoringSession1.tutoringId;
            string accountId = user1.accountId;

            if (response)
            {

                bool isDenied = await f.CancelTutoring(tutoringId, accountId);
                if (isDenied)
                {
                    await DisplayAlert("Info", "The Tutoring posting has been removed", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }

        }
    }
}