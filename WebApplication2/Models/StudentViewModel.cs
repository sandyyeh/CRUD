﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class StudentViewModel
    {
        public List<Student> StudentList { get; set; }
        public Student Student { get; set; }
    }
}