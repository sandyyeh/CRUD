using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interface
{
    interface ICourseSelectionRepository
    {
        List<Student_Class> GetAll();
        Student_Class GetDetail(string id);
        void Create(string id, string[] selectedClasses);
        void Update(string id, string[] selectedClasses);
        void Delete(string id);
        List<SelectListItem> GetStudentListItems(string id);
        List<SelectListItem> GetClassListItems(string id);
        List<ClassCheckboxItem> GetClassCheckboxes(string id);
        List<SelectListItem> GetStudentListItems();
        String GetClassName(string id);
    }
}
