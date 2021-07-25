using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Repository.Interface;
using WebApplication2.Service.Interface;

namespace WebApplication2.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetDetail(string id)
        {
            return _studentRepository.GetDetail(id);
        }

        public void Create(Student student)
        {
            if (student.Name != null)
            {
                _studentRepository.Create(student);
            }
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }

        public void Delete(string id)
        {
            _studentRepository.Delete(id);
        }
    }
}