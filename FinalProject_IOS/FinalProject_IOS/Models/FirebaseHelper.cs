using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace FinalProject_IOS.Models
{
    public class FirebaseHelper
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://student-ceef8-default-rtdb.firebaseio.com/");

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

        public async Task addUserToPendingList(string accountId, string courseId, string username, string password, string firstname, string lastname, string email, string role, string status)
        {

            await firebaseClient.Child("Users").PostAsync(new User() { accountId = accountId, courseId = courseId, userName = username, password = password, firstName = firstname, lastName = lastname, email = email, role = role, userStatus = status});
        }

        public async Task<User> GetByID(string sID)
        {
            return (await firebaseClient.Child(nameof(User)
                    + "/" + sID).OnceSingleAsync<User>());
        }

        public async Task<bool> Accept(string sID)
        {
            var toUpdatePerson = (await firebaseClient
              .Child("Users")
              .OnceAsync<User>()).Where(a => a.Object.accountId == sID).FirstOrDefault();

            await firebaseClient
              .Child("Users")
              .Child(toUpdatePerson.Key)
              .PutAsync(new User()
              {
                  accountId = toUpdatePerson.Object.accountId,
                  courseId = toUpdatePerson.Object.courseId,
                  email = toUpdatePerson.Object.email,
                  firstName = toUpdatePerson.Object.firstName,
                  lastName = toUpdatePerson.Object.lastName,
                  password = toUpdatePerson.Object.password,
                  role = toUpdatePerson.Object.role,
                  userName = toUpdatePerson.Object.userName,
                  userStatus = "Accepted"
              });

            return true;
        }

        public async Task<bool> Deny(string sID)
        {
            var toUpdatePerson = (await firebaseClient
              .Child("Users")
              .OnceAsync<User>()).Where(a => a.Object.accountId == sID).FirstOrDefault();

            await firebaseClient
              .Child("Users")
              .Child(toUpdatePerson.Key)
              .PutAsync(new User()
                {
                    accountId = toUpdatePerson.Object.accountId,
                    courseId = toUpdatePerson.Object.courseId,
                    email = toUpdatePerson.Object.email,
                    firstName = toUpdatePerson.Object.firstName,
                    lastName = toUpdatePerson.Object.lastName,
                    password = toUpdatePerson.Object.password,
                    role = toUpdatePerson.Object.role,
                    userName = toUpdatePerson.Object.userName,
                    userStatus = "Denied"
                });

            return true;
        }

        public async Task<List<User>> GetAllUsersPending()
        {
            return (await firebaseClient.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                accountId = item.Object.accountId,
                firstName = item.Object.firstName,
                lastName = item.Object.lastName,
                courseId = item.Object.courseId,
                role = item.Object.role

            }).ToList();
        }


        public FirebaseHelper()
        {
        }
    }
}
