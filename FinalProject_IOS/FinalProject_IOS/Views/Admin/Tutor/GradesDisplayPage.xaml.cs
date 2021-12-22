using FinalProject_IOS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Admin.Tutor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GradesDisplayPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        Tutoring t = new Tutoring();
        User u = new User();
        public GradesDisplayPage(string accountId)
        {
            InitializeComponent();
            u.accountId = accountId;
            
        }
        protected override async void OnAppearing()
        {
            
            var allGrades = await f.GetByTutoringSessionByTutorId(u.accountId);

            tutorGradesListView.ItemsSource = null;
            tutorGradesListView.ItemsSource = allGrades;


        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutorManagementPage());
        }

    }
}