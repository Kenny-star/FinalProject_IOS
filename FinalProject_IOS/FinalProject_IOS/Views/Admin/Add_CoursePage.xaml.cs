using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_IOS.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_CoursePage : ContentPage
    {
        // Initialize Firebase helper class
        FirebaseHelper fbHelper = new FirebaseHelper();

        public Add_CoursePage()
        {
            InitializeComponent();
        }


        // Add course
        private async void AddTutoringSession_Clicked(object sender, EventArgs e)
        {

            string courseId = CourseId.Text;
            string courseName = CourseName.Text;
            string teacherName = TeacherName.Text;

            await fbHelper.addCourse(courseId, courseName, teacherName);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseManagementPage());
        }
    }
}