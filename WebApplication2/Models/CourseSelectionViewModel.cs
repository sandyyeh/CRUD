using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class CourseSelectionViewModel
    {
        public string StudentId { get; set; }
        public List<Student_ClassViewModel> Student_ClassList { get; set; }
        public EditViewModel EditViewModel { get; set; }
        public CreateViewModel CreateViewModel { get; set; }
        public Student_Class Detail { get; set; }
    }

    public class Student_ClassViewModel
    {
        public string StudentId { get; set; }
        public string ClassName { get; set; }
    }

    public class EditViewModel
    {
        public Student_Class Detail { get; set; }
        public List<SelectListItem> StudentListItems { get; set; }
        public List<ClassCheckboxItem> ClassListItems { get; set; }
        public EditViewModel()
        {
            ClassListItems = new List<ClassCheckboxItem>();
        }
    }

    public class CreateViewModel
    {
        public List<SelectListItem> StudentListItems { get; set; }
        public List<ClassCheckboxItem> ClassListItems { get; set; }
        public CreateViewModel()
        {
            ClassListItems = new List<ClassCheckboxItem>();
        }
    }

    public class ClassCheckboxItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

}
