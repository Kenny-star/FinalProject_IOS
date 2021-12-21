using FinalProject_IOS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Tutoring tutor = new Tutoring();
        FirebaseHelper f = new FirebaseHelper();

        public TutorAssignmentMenuPage(Tutoring t)
        {
            InitializeComponent();

            tutor.tutoringId = t.tutoringId;
            tutor.tutorId = t.tutorId;
            tutor.firstName = t.firstName;
            tutor.lasttName = t.lasttName;
            tutor.date = t.date;
            tutor.startTime = t.startTime;
            tutor.endTime = t.endTime;
        }
        public TutorAssignmentMenuPage()
        { }

        protected override void OnAppearing()
        {
            ObservableCollection<Tutoring> target = new ObservableCollection<Tutoring>();

            tutorListView.ItemsSource = null;
            tutorListView.ItemsSource = target;

            target.Add(new Tutoring{tutorId = tutor.tutorId, firstName = tutor.firstName, lasttName = tutor.lasttName});

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssignTutorsPage());
        }

        private async void AddTutor_Clicked(object sender, EventArgs e)
        {
            string courseName = CourseName.Text;
            string teacherName = TeacherName.Text;
            string tutoringId = tutor.tutoringId;
            string tutorId = tutor.tutorId;
            string firstName = tutor.firstName;
            string lasttName = tutor.lasttName;
            string date = tutor.date;
            string startTime = tutor.startTime;
            string endTime = tutor.endTime;

            bool response = await f.AssignTutorToCourse(courseName, teacherName, tutoringId, tutorId, firstName, lasttName, date, startTime, endTime);

            if(response)
            {
                await DisplayAlert("Notice", "Tutor has been successfully assigned to a course and teacher", "OK");
                await Navigation.PushAsync(new AssignTutorsPage());

            }
            else
            {
                await DisplayAlert("Error", "Failed to assign a course and a teacher to the tutor!", "OK");
            }
        }

    }
}