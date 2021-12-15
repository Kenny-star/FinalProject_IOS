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
    public partial class CourseEditPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        public CourseEditPage(Course course)
        {
            InitializeComponent();
            courseID.Text = course.courseId;
            courseNAme.Text = course.courseName;
            teacherNAme.Text = course.teacherName;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            string courseId = courseID.Text;
            string courseName = courseNAme.Text;
            string teacherName = teacherNAme.Text;

            if (String.IsNullOrEmpty(courseId))
            {
                await DisplayAlert("Required", "Enter Course Id", "OK");
            }
            if (String.IsNullOrEmpty(courseName))
            {
                await DisplayAlert("Required", "Enter Course Name", "OK");
            }
            if (String.IsNullOrEmpty(teacherName))
            {
                await DisplayAlert("Required", "Enter Teacher Name", "OK");
            }

            Course course = new Course();
            course.courseId = courseID.Text;
            course.courseName = courseNAme.Text;
            course.teacherName = teacherNAme.Text;


            bool isUpdated = await f.EditCourse(course);
            if (isUpdated)
            {
                await DisplayAlert("Success", "Course information updated.", "OK");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Failed", "Did not save", "Cancel");
            }
            ClearStudent();

        }
        private void ClearStudent()
        {
            courseID.Text = String.Empty;
            courseNAme.Text = String.Empty;
            teacherNAme.Text = String.Empty;

        }

    }
}