using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class DBService
    {
        modelEntities db = new modelEntities();

        //public List<Student> GetStudentList()
        //{
        //    IQueryable<Student> result = db.Student;
        //    return result.ToList();
        //}

        //public Student GetStudent(string id)
        //{
        //    Student result = this.GetStudentList().Where(o => o.StudentID == id).FirstOrDefault();
        //    return result;
        //}
        //public void CreateStudent(Student param)
        //{
        //    Student student = new Student()
        //    {
        //        Name = param.Name,
        //        Birthday = param.Birthday,
        //        Email = param.Email
        //    };

        //    db.Student.Add(student);
        //    db.SaveChanges();
        //}

        //public void UpdateStudent(Student param)
        //{
        //    Student student = new Student();
        //    student = db.Student.Find(param.StudentID);
        //    student.Name = param.Name;
        //    student.Birthday = param.Birthday;
        //    student.Email = param.Email;

        //    db.Entry(student).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        //public void DeleteStudent(string id)
        //{
        //    Student student = new Student();
        //    student = db.Student.Find(id);

        ////    db.Entry(student).State = EntityState.Deleted;
        ////    db.SaveChanges();
        ////}

        //public List<Class> GetClassList()
        //{
        //    IQueryable<Class> result = db.Class;
        //    return result.ToList();
        //}
        //public Class GetClass(string classId)
        //{
        //    Class result = this.GetClassList().Where(o => o.ClassID == classId).FirstOrDefault();
        //    return result;
        //}

        //public void CreateClass(Class param)
        //{
        //    Class classDetail = new Class()
        //    {
        //        ClassName = param.ClassName,
        //        Credit = param.Credit,
        //        Teacher = param.Teacher,
        //        Location = param.Location
        //    };

        //    db.Class.Add(classDetail);
        //    db.SaveChanges();
        //}

        //public void UpdateClass(Class param)
        //{
        //    Class classDetail = new Class();
        //    classDetail = db.Class.Find(param.ClassID);
        //    classDetail.ClassName = param.ClassName;
        //    classDetail.Credit = param.Credit;
        //    classDetail.Teacher = param.Teacher;
        //    classDetail.Location = param.Location;

        //    db.Entry(classDetail).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        //public void DeleteClass(string classId)
        //{
        //    Class classDetail = new Class();
        //    classDetail = db.Class.Find(classId);

        //    db.Entry(classDetail).State = EntityState.Deleted;
        //    db.SaveChanges();
        //}

        //public CourseSelectionModel GetStudentsAndClasses(string studentId)
        //{
        //    IQueryable<Student_Class> studentAndClassList = db.Student_Class;
        //    List<Student_Class> student_Class = studentAndClassList.ToList();
        //    List<Student> studentList = this.GetStudentList();
        //    List<Class> classList = this.GetClassList();
        //    var query = from student in studentList
        //                join data in student_Class on student.StudentID equals data.StudentID
        //                join classitem in classList on 1 equals 1
        //                where (data.StudentID == studentId && data.ClassID.Contains(classitem.ClassID))
        //                select (student.Name, classitem.ClassID, classitem.ClassName);


        //    CourseSelectionModel result = new CourseSelectionModel
        //    {



        //    };
        //    return result;

        //    //select s.studentid,s.name,c.classname
        //    //from student s
        //    //join student_class sc on sc.studentid = s.studentid
        //    //join class c on sc.classid  LIKE '%'+c.classid+'%'
        //    //order by studentid


        //}
    }
}