using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CourseSelectionModel
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public List<string> ClassId { get; set; }
        public string ClassName { get; set; }

    }
}