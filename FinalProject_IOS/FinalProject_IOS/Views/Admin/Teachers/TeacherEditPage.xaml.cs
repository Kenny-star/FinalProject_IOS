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
    public partial class TeacherEditPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        public TeacherEditPage(User teacher)
        {
            InitializeComponent();

            accountId.Text = teacher.accountId;
            firstName.Text = teacher.firstName;
            lastName.Text = teacher.lastName;
            emailAddr.Text = teacher.email;
            username.Text = teacher.userName;
            password.Text = teacher.password;
            courseId.Text = teacher.courseId;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            string AccountID = accountId.Text;
            string FirstName = firstName.Text;
            string LastName = lastName.Text;
            string Email = emailAddr.Text;
            string userName = username.Text;
            string pwd = password.Text;
            string CourseId = courseId.Text;


            if (String.IsNullOrEmpty(FirstName))
            {
                await DisplayAlert("Required", "Enter teacher's first name", "OK");
            }

            if (String.IsNullOrEmpty(LastName))
            {
                await DisplayAlert("Required", "Enter teacher's last name", "OK");
            }

            if (String.IsNullOrEmpty(Email))
            {
                await DisplayAlert("Required", "Enter teacher's email", "OK");
            }

            if (String.IsNullOrEmpty(userName))
            {
                await DisplayAlert("Required", "Enter teacher's username", "OK");
            }

            if (String.IsNullOrEmpty(pwd))
            {
                await DisplayAlert("Required", "Enter teacher's password", "OK");
            }

            if (String.IsNullOrEmpty(CourseId))
            {
                await DisplayAlert("Required", "Enter teacher's course ID.", "OK");
            }


            User teacher = new User();
            teacher.accountId = accountId.ToString();
            teacher.firstName = FirstName;
            teacher.lastName = LastName;
            teacher.email = Email;
            teacher.userName = userName;
            teacher.password = pwd;
            teacher.courseId = CourseId;


            bool isUpdated = await f.EditTeacher(teacher);
            if (isUpdated)
            {
                await DisplayAlert("Success", "Teacher information updated.", "OK");
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
            //courseID.Text = String.Empty;
            //courseNAme.Text = String.Empty;
            //teacherNAme.Text = String.Empty;

        }

    }
}