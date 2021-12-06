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
        // Initialize Firebase helper

        FirebaseHelper fbHelper = new FirebaseHelper();

        public Add_CoursePage()
        {
            InitializeComponent();

            string courseId = CourseIdField.Text;
        }

        private async void AddTutoringSession_Clicked(object sender, EventArgs e)
        {
            await fbHelper.addCourse(CourseIdField.Text, "Tristan", "Giguere");
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseManagementPage());
        }
    }
}