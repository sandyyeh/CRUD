using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interface;

namespace WebApplication2.Repository
{
    public class CourseSelectionRepository : ICourseSelectionRepository
    {
        modelEntities db = new modelEntities();
        private IStudentRepository studentRep;
        private IClassRepository classRep;

        public CourseSelectionRepository()
        {
            studentRep = new StudentRepository();
            classRep = new ClassRepository();
        }

        public void Create(string id, string[] selectedClasses)
        {
            Student_Class model = new Student_Class();
            model.StudentID = id;
            model.ClassID = string.Join(",", selectedClasses) + ",";
            db.Student_Class.Add(model);

            db.SaveChanges();
        }

        public void Delete(string id)
        {
            Student_Class data = new Student_Class();
            data = db.Student_Class.Find(id);

            db.Entry(data).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Student_Class> GetAll()
        {
            IQueryable<Student_Class> studentAndClassList = db.Student_Class;
            return studentAndClassList.ToList();
        }

        public Student_Class GetDetail(string id)
        {
            Student_Class result = this.GetAll().Where(o => o.StudentID == id).FirstOrDefault();
            return result;
        }

        public void Update(string id, string[] selectedClasses)
        {
            Student_Class data = new Student_Class();
            data = db.Student_Class.Find(id);
            data.ClassID = string.Join(",", selectedClasses) + ",";
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<SelectListItem> GetStudentListItems(string id)
        {
            Student student = studentRep.GetDetail(id);
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Text = student.StudentID + "(" + student.Name + ")",
                Value = student.StudentID
            });
            return listItems;
        }

        public String GetClassName(string id)
        {
            List<String> classStrList = GetDetail(id).ClassID.Split(',').ToList();//每個科目
            List<Class> classList = classRep.GetAll();//所有科目資料
            string className = "";
            foreach (var classStr in classStrList)
            {
                foreach (var item in classList)
                {
                    if (classStr == item.ClassID)
                    {
                        className = className + item.ClassName + "、";
                    }
                }
            }
            className = className.Remove(className.Length - 1);

            return className;
        }

        public List<SelectListItem> GetStudentListItems()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            List<Student_Class> student_Class = GetAll();
            List<Student> studentList = studentRep.GetAll();
            var query = from s in studentList
                        where !student_Class.Any(o => (o.StudentID == s.StudentID))
                        select (s.StudentID, s.Name);

            foreach (var item in query)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = item.StudentID + "(" + item.Name + ")",
                    Value = item.StudentID
                });
            }
            return listItems;
        }

        public List<ClassCheckboxItem> GetClassCheckboxes(string id)
        {
            List<ClassCheckboxItem> classList = new List<ClassCheckboxItem>();

            foreach (var item in classRep.GetAll())
            {
                classList.Add(new ClassCheckboxItem
                {
                    Id = item.ClassID,
                    Name = item.ClassName
                });
            }
            return classList;
        }

        public List<SelectListItem> GetClassListItems(string id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            List<Class> classList = classRep.GetAll();
            string detail = "";
            if (!string.IsNullOrEmpty(id))
            {
                detail = this.GetDetail(id).ClassID.ToString();
            }

            List<String> splitClasses = detail?.Split(',').ToList();
            foreach (var item in classList)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = item.ClassName,
                    Value = item.ClassID,
                    Selected = splitClasses.Contains(item.ClassID) ? true : false
                });
            }
            return listItems;
        }
    }
}