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
        // FirebaseClient firebaseClient = new FirebaseClient("https://student-ceef8-default-rtdb.firebaseio.com/");
        FirebaseClient firebaseClient = new FirebaseClient("https://ios-final-project-ed51f-default-rtdb.firebaseio.com/");

        // Add new course to Firebase database
        public async Task<bool> addCourse(string courseId, string name, string teacherName) {

            await firebaseClient.Child("Courses").PostAsync(new Course() { courseId = courseId, courseName = name, teacherName = teacherName });

            return true;
        }

        // Get a list of all the courses from the database
        public async Task<List<Course>> GetAllCourses()
        {
            return (await firebaseClient.Child("Courses").OnceAsync<Course>()).Select(item => new Course
            {
                courseId = item.Object.courseId,
                courseName = item.Object.courseName,
                teacherName = item.Object.teacherName,
            }).ToList();
        }


        public async Task<bool> DeleteCourse(string courseId)
        {
            var toDeleteCourse = (await firebaseClient.Child("Courses").OnceAsync<Course>()).FirstOrDefault(a => a.Object.courseId == courseId);

            await firebaseClient.Child("Courses").Child(toDeleteCourse.Key).DeleteAsync();

            return true;
        }



        public async Task<bool> EditCourse(Course course)
        {
            var toUpdateCourse = (await firebaseClient.Child("Courses").OnceAsync<Course>()).Where(a => a.Object.courseId == course.courseId).FirstOrDefault();

            await firebaseClient.Child("Courses").Child(toUpdateCourse.Key).PutAsync(new Course() { courseId = course.courseId, courseName = course.courseName, teacherName = course.teacherName });

            return true;
        }

        public async Task<Course> GetCourseByID(string courseId)
        {
            var allCourses = await GetAllCourses();
            await firebaseClient.Child("Persons").OnceAsync<Course>();
            return allCourses.Where(a => a.courseId == courseId).FirstOrDefault();
        }


        public async Task AddUserToPendingList(string accountId, string courseId, string username, string password, string firstname, string lastname, string email, string role, string status)
        {

            await firebaseClient.Child("Users").PostAsync(new User() { accountId = accountId, courseId = courseId, userName = username.ToLower(), password = password, firstName = firstname, lastName = lastname, email = email, role = role, userStatus = status });
        }

        public async Task<User> GetByID(string sID)
        {
            return await firebaseClient.Child(nameof(User)
                    + "/" + sID).OnceSingleAsync<User>();
        }

        public async Task<bool> AcceptUserAccessFromRegistration(string sID)
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

        public async Task<bool> DenyUserAccessFromRegistration(string sID)
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

        public async Task<List<User>> GetAllUsers()
        {
            return (await firebaseClient.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                accountId = item.Object.accountId,
                courseId = item.Object.courseId,
                firstName = item.Object.firstName,
                lastName = item.Object.lastName,
                role = item.Object.role,
                userName = item.Object.userName,
                password = item.Object.password,
                userStatus = item.Object.userStatus


            }).ToList();
        }

        public async Task<bool> AddAvailability(string accountId, string firstName1, string lastName, string availability, string start, string end)
        {
            /*
            var toUpdatePerson = (await firebaseClient
            .Child("Users")
            .OnceAsync<User>()).Where(a => a.Object.role == "Tutor" && a.Object.accountId == accountId).FirstOrDefault();

            if (toUpdatePerson == null)
            {
                return false;
            }
            else
            {

                await firebaseClient.Child("Users").Child("Tutoring").Child(toUpdatePerson.Key).PostAsync(new Tutoring()
                {
                    firstName = firstName,
                    lasttName = lastName,
                    date = availability,
                    startTime = start,
                    endTime = end,

                });

                return true;
            }
            */

            await firebaseClient.Child("Users").Child("Tutoring").PostAsync(new Tutoring()
            {
                firstName = firstName1,
                lasttName = lastName,
                tutorId = accountId,
                date = availability,
                startTime = start,
                endTime = end

            });

            return true;
        }

        public async Task<List<Tutoring>> GetAllTutoringOffers()
        {
            return (await firebaseClient.Child("Users").Child("Tutoring").OnceAsync<Tutoring>()).Select(item => new Tutoring
            {
                tutorId = item.Object.tutorId,
                firstName = item.Object.firstName,
                lasttName = item.Object.lasttName,
                date = item.Object.date,
                startTime = item.Object.startTime,
                endTime = item.Object.endTime,


            }).ToList();
        }

        public async Task<Tutoring> GetTutorByID(string SId)
        {
            var allTutors = await GetAllTutoringOffers();
            await firebaseClient.Child("User").Child("Tutoring").OnceAsync<Tutoring>();
            return allTutors.Where(a => a.tutorId == SId).FirstOrDefault();
        }

        public async Task<List<Tutoring>> GetByTutorId(string sId)
        {
            return (await firebaseClient.Child("User").Child("Tutoring").OnceAsync<Tutoring>()).Where(s => s.Object.tutorId == sId).Select(item => new Tutoring
            {
                tutorId = item.Object.tutorId,
                firstName = item.Object.firstName,
                lasttName = item.Object.lasttName,
                date = item.Object.date,
                startTime = item.Object.startTime,
                endTime = item.Object.endTime

            }).ToList();
        }


        //  ------------------------------------------                       ------------------------------------------
        //  ------------------------------------------   CRUD For teachers   ------------------------------------------
        //  ------------------------------------------                       ------------------------------------------


        // Delete teacher by its account ID
        public async Task<bool> DeleteTeacher(string accountId)
        {
            var toDeleteTeacher = (await firebaseClient.Child("Users").OnceAsync<User>()).FirstOrDefault(a => a.Object.accountId == accountId);

            await firebaseClient.Child("Users").Child(toDeleteTeacher.Key).DeleteAsync();

            return true;
        }


        // Add new teacher to Firebase DB
        public async Task<bool> AddTeacher(string accountId, string courseId, string username, string password, string firstname, string lastname, string email)
        {

            await firebaseClient.Child("Users").PostAsync(new User() { accountId = accountId, courseId = courseId, userName = username.ToLower(), password = password, firstName = firstname, lastName = lastname, email = email, role = "Teacher", userStatus = "Accepted" });
            return true;
        }



        // Get teacher from its accountId

        public async Task<User> GetTeacherById(string accountId)
        {
            var allUsers = await GetAllUsers();
            await firebaseClient.Child("Users").OnceAsync<User>();
            return allUsers.Where(a => a.accountId == accountId).FirstOrDefault();
        }

        // Update teacher account

        public async Task<bool> EditTeacher(User teacher)
        {
            var toUpdateTeacher = (await firebaseClient.Child("Users").OnceAsync<User>()).Where(a => a.Object.accountId == teacher.accountId).FirstOrDefault();

            await firebaseClient.Child("Users").Child(toUpdateTeacher.Key).PutAsync(new User() { accountId = teacher.accountId, firstName = teacher.firstName, lastName = teacher.lastName, email = teacher.email, userName = teacher.userName.ToLower(), password = teacher.password, courseId = teacher.courseId  });

            return true;
        }

        //  ------------------------------------------                       ------------------------------------------
        //  ------------------------------------------   CRUD FOR TUTORS   ------------------------------------------
        //  ------------------------------------------                       ------------------------------------------


        // Delete tutor by its account ID
        public async Task<bool> DeleteTutor(string accountId)
        {
            var toDeleteTutor = (await firebaseClient.Child("Users").OnceAsync<User>()).FirstOrDefault(a => a.Object.accountId == accountId);

            await firebaseClient.Child("Users").Child(toDeleteTutor.Key).DeleteAsync();

            return true;
        }


        // Add new tutor to Firebase DB
        public async Task<bool> AddTutor(string accountId, string courseId, string username, string password, string firstname, string lastname, string email)
        {

            await firebaseClient.Child("Users").PostAsync(new User() { accountId = accountId, courseId = courseId, userName = username.ToLower(), password = password, firstName = firstname, lastName = lastname, email = email, role = "Tutor", userStatus = "Accepted" });
            return true;
        }

        // Get tutor from its accountId

        public async Task<User> GetTutorById(string accountId)
        {
            var allUsers = await GetAllUsers();
            await firebaseClient.Child("Users").OnceAsync<User>();
            return allUsers.Where(a => a.accountId == accountId).FirstOrDefault();
        }

        // Update tutor account

        public async Task<bool> EditTutor(User tutor)
        {
            var toUpdateTutor = (await firebaseClient.Child("Users").OnceAsync<User>()).Where(a => a.Object.accountId == tutor.accountId).FirstOrDefault();

            await firebaseClient.Child("Users").Child(toUpdateTutor.Key).PutAsync(new User() { accountId = tutor.accountId, firstName = tutor.firstName, lastName = tutor.lastName, email = tutor.email, userName = tutor.userName.ToLower(), password = tutor.password, courseId = tutor.courseId });

            return true;
        }
























        public FirebaseHelper()
        {
        }
    }
}
