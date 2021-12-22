using FinalProject_IOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Tutor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedBackFormPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        User u = new User();
        Tutoring t = new Tutoring();
        User tu = new User();
        public FeedBackFormPage(User user, Tutoring tutoring, User tutee)
        {
            InitializeComponent();
            u.accountId = user.accountId;
            u.courseId = user.courseId;
            u.firstName = user.firstName;
            u.lastName = user.lastName;
            u.role = user.role;

            t.courseName = tutoring.courseName;
            t.date = tutoring.date;
            t.endTime = tutoring.endTime;
            t.startTime = tutoring.startTime;
            t.date = tutoring.date;
            t.firstName = tutoring.firstName;
            t.lasttName = tutoring.lasttName;
            t.tutorId = tutoring.tutorId;
            t.tutoringId = tutoring.tutoringId;

            tu.accountId = tutee.accountId;
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutorFeedBackPage(u,t));
        }
        private async void GiveFeedBackToTutee(object sender, EventArgs e)
        {
            string date = t.date;
            string endTime = t.endTime;
            string startTime = t.startTime;
            string firstName = t.firstName;
            string lasttName = t.lasttName;
            string feedback = FeedBack.Text;
            string accountId = tu.accountId;
            string tutoringId = t.tutoringId;
            bool response = await f.GiveFeedBack(tutoringId, accountId, feedback, date, endTime, startTime, firstName, lasttName);

            if (response)
            {
                await DisplayAlert("Notice", "Tutoring Session Feedback has been successfully submitted", "OK");
                await Navigation.PushAsync(new TutorFeedBackPage(u, t, tu));

            }
            else
            {
                await DisplayAlert("Error", "Failed to submit feedback!", "OK");
            }
        }
    }
}