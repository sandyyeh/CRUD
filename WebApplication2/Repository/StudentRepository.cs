using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Repository.Interface;

namespace WebApplication2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        modelEntities db = new modelEntities();

        public void Create(Student param)
        {
            Student student = new Student()
            {
                Name = param.Name,
                Birthday = param.Birthday,
                Email = param.Email
            };

            db.Student.Add(student);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            Student student = new Student();
            student = db.Student.Find(id);

            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Student> GetAll()
        {
            IQueryable<Student> result = db.Student;
            return result.ToList();

        }

        public Student GetDetail(string id)
        {
            Student result = this.GetAll().Where(o => o.StudentID == id).FirstOrDefault();
            return result;
        }

        public void Update(Student param)
        {
            Student student = new Student();
            student = db.Student.Find(param.StudentID);
            student.Name = param.Name;
            student.Birthday = param.Birthday;
            student.Email = param.Email;

            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}