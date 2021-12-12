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
    public partial class AddSession : ContentPage
    {
        User user1 = new User();
        FirebaseHelper f = new FirebaseHelper();
        public AddSession(User user)
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

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TutorDashboardPage(user1));
        }

        private async void AddTutoringSession_Clicked(object sender, EventArgs e)
        {
            string accountId = user1.accountId;
            string firstName = user1.firstName;
            string lasttName = user1.lastName;
            string availability = DateInput.Date.ToString();
            string start = StartTime.Time.ToString();
            string end = EndTime.Time.ToString();

            bool response = await f.AddAvailability(accountId, firstName, lasttName, availability, start, end);

            if (response)
            {
                await DisplayAlert("Notice", "You have successfully posted your availability!", "OK");

                await Navigation.PushAsync(new TutorDashboardPage());
            }

            else
            {
                await DisplayAlert("Error", "An error occured while inserting!", "OK");
            }
        }
    }
}