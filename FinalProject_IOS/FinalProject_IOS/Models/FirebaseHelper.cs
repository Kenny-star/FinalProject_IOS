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








        public FirebaseHelper()
        {
        }
    }
}
