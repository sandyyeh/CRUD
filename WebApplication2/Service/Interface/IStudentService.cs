using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Service.Interface
{
    public interface IStudentService
    {

        void Create(Student param);
        void Update(Student param);
        void Delete(string id);
        List<Student> GetAll();
        Student GetDetail(string id);
    }
}
