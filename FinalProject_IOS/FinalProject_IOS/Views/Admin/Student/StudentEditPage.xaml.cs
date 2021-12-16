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
    public partial class StudentEditPage : ContentPage
    {
        FirebaseHelper f = new FirebaseHelper();
        public StudentEditPage(User student)
        {
            InitializeComponent();

            accountId.Text = student.accountId;
            firstName.Text = student.firstName;
            lastName.Text = student.lastName;
            emailAddr.Text = student.email;
            username.Text = student.userName;
            password.Text = student.password;
            courseId.Text = student.courseId;
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
                await DisplayAlert("Required", "Enter student's first name", "OK");
            }

            if (String.IsNullOrEmpty(LastName))
            {
                await DisplayAlert("Required", "Enter student's last name", "OK");
            }

            if (String.IsNullOrEmpty(Email))
            {
                await DisplayAlert("Required", "Enter student's email", "OK");
            }

            if (String.IsNullOrEmpty(userName))
            {
                await DisplayAlert("Required", "Enter student's username", "OK");
            }

            if (String.IsNullOrEmpty(pwd))
            {
                await DisplayAlert("Required", "Enter student's password", "OK");
            }

            if (String.IsNullOrEmpty(CourseId))
            {
                await DisplayAlert("Required", "Enter student's course ID.", "OK");
            }


            User student = new User();
            student.accountId = AccountID.ToString();
            student.firstName = FirstName;
            student.lastName = LastName;
            student.email = Email;
            student.userName = userName;
            student.password = pwd;
            student.courseId = CourseId;


            bool isUpdated = await f.EditStudent(student);
            if (isUpdated)
            {
                await DisplayAlert("Success", "Student information updated.", "OK");
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