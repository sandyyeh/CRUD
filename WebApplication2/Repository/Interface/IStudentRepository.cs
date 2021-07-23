using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interface
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetDetail(string id);
        void Create(Student param);       
        void Update(Student param);
        void Delete(string id);
    }
}
