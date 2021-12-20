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
    public partial class TutoringPostings : ContentPage
    {
        User user1 = new User();
        FirebaseHelper f = new FirebaseHelper();
        public TutoringPostings(User user)
        {
            InitializeComponent();

            user1.accountId = user.accountId;
            user1.courseId = user.courseId;
            user1.userName = user.userName;
            user1.password = user.password;
            user1.firstName = user.firstName;
            user1.lastName = user.lastName;
            user1.email = user.email;
            user1.role = user.role;
        }
        public TutoringPostings()
        {
            InitializeComponent();
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutorDashboardPage(user1));
        }
        protected override async void OnAppearing()
        {

            var myTutoringAvailabilities = await f.GetMyTutoringOffers(user1.accountId);

            tutorPostingsListView.ItemsSource = null;
            tutorPostingsListView.ItemsSource = myTutoringAvailabilities;
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            var tutor = await f.GetByTutoringSessionById(sID);

            if (tutor == null)
            {
                await DisplayAlert("Warning", "tutor not found", "OK");
            }
            else
            {
                await Navigation.PushAsync(new EditTutoringPostingPage(tutor, user1));

            }

        }

        private async void Delete_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm Deletion", "Do you want to remove this tutoring posting from the list?", "Yes", "No");
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            if (response)
            {

                bool isDenied = await f.DeleteTutoring(sID);
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