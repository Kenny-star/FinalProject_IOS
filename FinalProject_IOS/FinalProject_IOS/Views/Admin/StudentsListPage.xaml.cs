using FinalProject_IOS.Models;
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
    public partial class StudentsListPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        Tutoring t = new Tutoring();
        public StudentsListPage(Tutoring tutoringSession)
        {
            InitializeComponent();

            t.tutorId = tutoringSession.tutorId;
            t.tutoringId = tutoringSession.tutoringId;
        }


        protected override async void OnAppearing()
        {

            var allStudents = await f.GetMyTutoringStudents(t.tutoringId);

            tuteesListView.ItemsSource = null;
            tuteesListView.ItemsSource = allStudents;


        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssignTutorsPage());
        }
    }
}