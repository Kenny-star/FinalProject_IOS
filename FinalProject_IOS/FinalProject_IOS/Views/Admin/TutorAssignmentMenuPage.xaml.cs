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

            tutor.tutorId = t.tutorId;
            tutor.firstName = t.firstName;
            tutor.lasttName = t.lasttName;
            tutor.date = t.date;
            tutor.startTime = t.startTime;
            tutor.lasttName = t.lasttName;
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

        private void AddTutor_Clicked(object sender, EventArgs e)
        {
            //Insert to db
        }

    }
}