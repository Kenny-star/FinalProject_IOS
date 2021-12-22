using FinalProject_IOS.Models;
using FinalProject_IOS.Views.Admin;
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
    public partial class AttendedHoursPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        Tutoring t = new Tutoring();
        User u = new User();
        public AttendedHoursPage(string accountId)
        {
            InitializeComponent();
            u.accountId = accountId;

        }
        protected override async void OnAppearing()
        {

            var allStudents = await f.GetByTutoringSessionByTuteeId(u.accountId);

            studentsListView.ItemsSource = null;
            studentsListView.ItemsSource = allStudents;


        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentManagementPage());
        }
    }
}