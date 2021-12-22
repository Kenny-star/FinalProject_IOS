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
    public partial class TutorFeedBackPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        User u = new User();
        User tu = new User();
        Tutoring t = new Tutoring();
        public TutorFeedBackPage(User user, Tutoring tutoring, User u2)
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

            tu.accountId = u2.accountId;
        }

        public TutorFeedBackPage(User user, Tutoring tutoring)
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
        }
            private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutoringPostings(u));
        }

        protected override async void OnAppearing()
        {

            var myTutees = await f.GetMyTutoringStudents(t.tutoringId);

            tutorStudentsListView.ItemsSource = null;
            tutorStudentsListView.ItemsSource = myTutees;
        }

        private async void DeleteTutee_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm Deletion", "Do you want to remove this tutee from the list?", "Yes", "No");
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            
            if (response)
            {
                
                bool isDenied = await f.CancelTutoring(t.tutoringId, sID);
                if (isDenied)
                {
                    await DisplayAlert("Info", "The tutee has been removed", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }
        }

        private async void ReportTutoringSession_Clicked(object sender, EventArgs e)
        {
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            var tutee = await f.GetStudentById(sID);
            await Navigation.PushAsync(new FeedBackFormPage(u,t, tutee));
        }

    }
}