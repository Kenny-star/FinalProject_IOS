﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_IOS.Models
{
    public class Teacher
    {
        public string accountId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string courseId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public Status userStatus { get; set; }
    }

   
}
