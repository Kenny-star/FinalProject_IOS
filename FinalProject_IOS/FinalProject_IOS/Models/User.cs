using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_IOS.Models
{
    public class User
    {
        public string tutoringId { get; set; }
        public string accountId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string courseId { get; set; }
        public string feedback { get; set; }
        public List<Course> courseLoad { get; set; }
        public List<Tutoring> tutoring { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string userStatus { get; set; }

    }
}
