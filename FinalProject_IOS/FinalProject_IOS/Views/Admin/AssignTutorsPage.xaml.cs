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
    public partial class AssignTutorsPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        public AssignTutorsPage()
        {//Should have a mvvm or and Onclick to pass object to new navigation.
            InitializeComponent();

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }

        private async void AssignTutor_Clicked(object sender, EventArgs e)
        {
            string tutorId = ((TappedEventArgs)e).Parameter.ToString();
            var tutor = await f.GetTutorByID(tutorId);

            if (tutor == null)
            {
                await DisplayAlert("Warning", "tutor not found", "OK");
            }
            else
            {
                await Navigation.PushAsync(new TutorAssignmentMenuPage(tutor));
            }
            
        }

        private async void ViewTutor_Clicked(object sender, EventArgs e)
        {
            string tutoringId = ((TappedEventArgs)e).Parameter.ToString();
            var tutor = await f.GetByTutoringSessionById(tutoringId);
            await Navigation.PushAsync(new StudentsListPage(tutor));
        }

        protected override async void OnAppearing()
        {

            var tutoringAvailabilities = await f.GetAllTutoringOffers();
            
            tutorsListView.ItemsSource = null;
            tutorsListView.ItemsSource = tutoringAvailabilities;

            
        }

        private async void GradeTutor_Clicked(object sender, EventArgs e)
        {
            string tutoringId = ((TappedEventArgs)e).Parameter.ToString();
            var tutor = await f.GetByTutoringSessionById(tutoringId);
            await Navigation.PushAsync(new GradingGridPage(tutor));
        }
        /*
        private async void DeleteCourse_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm Deletion", "Do you want to remove this course from the course list?", "Yes", "No");
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            if (response)
            {

                bool isDenied = await f.DeleteCourse(sID);
                if (isDenied)
                {
                    await DisplayAlert("Info", "Course is removed", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Warning", "Action failed", "OK");
                }
            }

        }

        private async void EditCourse_Tapped(object sender, EventArgs e)
        {
            string courseId = ((TappedEventArgs)e).Parameter.ToString();
            var course = await f.GetCourseByID(courseId);

            if (course == null)
            {
                await DisplayAlert("Warning", "course not found", "OK");
            }
            else
            {
                course.courseId = courseId;
                await Navigation.PushModalAsync(new CourseEditPage(course));
                OnAppearing();
            }

        }*/

    }
}