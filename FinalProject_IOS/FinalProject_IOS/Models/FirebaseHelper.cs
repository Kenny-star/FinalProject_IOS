using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;

namespace FinalProject_IOS.Models
{
    public class FirebaseHelper
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://ios-final-project-ed51f-default-rtdb.firebaseio.com/");

        // Add new course to Firebase database
        public async Task addCourse(string courseId, string name, string teacherName) {

            await firebaseClient.Child("Courses").PostAsync(new Course() { courseId = courseId, name = name, teacherName = teacherName });
        }

        // Get a list of all the courses from the database
        public async Task<List<Course>> GetAllCourses()
        {
            return (await firebaseClient.Child("Courses").OnceAsync<Course>()).Select(item => new Course
              {
                  courseId = item.Object.courseId,
                  name = item.Object.name,
                  teacherName = item.Object.teacherName,
              }).ToList();
        }



        // Register new teacher (pending status) to database
        public async Task registerTeacher(string accountId, string fName, string lName, string email, string courseId, string uName, string pwd)
        {

            await firebaseClient.Child("Users").PostAsync(new User() { accountId = accountId, firstName = fName, lastName = lName, email = email, courseId = courseId, userName = uName, password = pwd, grade = "0", role = Roles.Teacher, userStatus = Status.Pending });
        }

        // Register new student (pending status) to database
        public async Task registerStudent(string accountId, string fName, string lName, string email, string courseId, string uName, string pwd, string grade)
        {

            await firebaseClient.Child("Users").PostAsync(new User() { accountId = accountId, firstName = fName, lastName = lName, email = email, courseId = courseId, userName = uName, password = pwd, grade = grade, role = Roles.Tutee, userStatus = Status.Pending });
        }

        // Register new tutor (pending status) to database
        public async Task registerTutor(string accountId, string fName, string lName, string email, string courseId, string uName, string pwd, string grade)
        {

            await firebaseClient.Child("Users").PostAsync(new User() { accountId = accountId, firstName = fName, lastName = lName, email = email, courseId = courseId, userName = uName, password = pwd, grade = grade, role = Roles.Tutor, userStatus = Status.Pending });
        }






        public FirebaseHelper()
        {
        }
    }
}
