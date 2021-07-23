using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class DBService
    {
        modelEntities db = new modelEntities();

        public List<Student> GetStudentList()
        {
            IQueryable<Student> result = db.Student;
            return result.ToList();
        }

        public List<Class> GetClassList()
        {
            IQueryable<Class> result = db.Class;
            return result.ToList();
        }
        public Class GetClass(string classId)
        {
            Class result = this.GetClassList().Where(o => o.ClassID == classId).FirstOrDefault();
            return result;
        }

        public CourseSelectionModel GetStudentsAndClasses(string studentId)
        {
            IQueryable<Student_Class> studentAndClassList = db.Student_Class;
            List<Student_Class> student_Class = studentAndClassList.ToList();
            List<Student> studentList = this.GetStudentList();
            List<Class> classList = this.GetClassList();
            var query = from student in studentList
                        join data in student_Class on student.StudentID equals data.StudentID
                        join classitem in classList on 1 equals 1
                        where (data.StudentID == studentId && data.ClassID.Contains(classitem.ClassID))
                        select (student.Name, classitem.ClassID, classitem.ClassName);


            CourseSelectionModel result = new CourseSelectionModel
            {



            };
            return result;

            //select s.studentid,s.name,c.classname
            //from student s
            //join student_class sc on sc.studentid = s.studentid
            //join class c on sc.classid  LIKE '%'+c.classid+'%'
            //order by studentid


        }
    }
}