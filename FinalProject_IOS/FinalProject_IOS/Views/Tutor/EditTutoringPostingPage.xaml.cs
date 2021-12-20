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
    public partial class EditTutoringPostingPage : ContentPage
    {
        Tutoring t = new Tutoring();
        User u = new User();
        FirebaseHelper f = new FirebaseHelper();

        public EditTutoringPostingPage(Tutoring tutor, User user)
        {
            InitializeComponent();
            t.tutoringId = tutor.tutoringId;
            t.tutorId = tutor.tutorId;
            t.startTime = tutor.startTime;
            t.endTime = tutor.endTime;
            t.date = tutor.date;
            t.firstName = tutor.firstName;
            t.lasttName = tutor.lasttName;

            u.accountId = user.accountId;
            u.courseId = user.courseId;
            u.userName = user.userName;
            u.password = user.password;
            u.firstName = user.firstName;
            u.lastName = user.lastName;
            u.email = user.email;
            u.role = user.role;
        }

        public EditTutoringPostingPage() { InitializeComponent(); }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutoringPostings(u));
        }

        private async void EditTutoringSession_Clicked(object sender, EventArgs e)
        {
            string tutoringId = t.tutoringId;
            string accountId = t.tutorId;
            string firstName = t.firstName;
            string lasttName = t.lasttName;
            string availability = DateInput.Date.ToString("d");
            string start = StartTime.Time.ToString();
            string end = EndTime.Time.ToString();

            bool response = await f.EditAvailability(tutoringId, accountId, firstName, lasttName, availability, start, end);

            if (response)
            {
                await DisplayAlert("Notice", "You have successfully posted your availability!", "OK");

                await Navigation.PushAsync(new TutorDashboardPage(u));
            }

            else
            {
                await DisplayAlert("Error", "An error occured while inserting!", "OK");
            }
        }
    }
}