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
    public partial class CourseManagementPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        public CourseManagementPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {

            var courses = await f.GetAllCourses();

            coursesListView.ItemsSource = null;
            coursesListView.ItemsSource = courses;
        }

        private async void DeleteCourse_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Deny Access", "Do you want to remove this course from the course list?", "Yes", "No");
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
            string sID = ((TappedEventArgs)e).Parameter.ToString();
            var course = await f.GetCourseByID(sID);
            
            if (course == null)
            {
                await DisplayAlert("Warning", "course not found", "OK");
            }
            else
            {
                course.courseId = sID;
                await Navigation.PushModalAsync(new CourseEditPage(course));
                OnAppearing();
            }

        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminDashboardPage());
        }

        private void Add_Course_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add_CoursePage());
        }
    }
}