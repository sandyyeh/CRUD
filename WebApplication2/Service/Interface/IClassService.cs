using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Service.Interface
{
    public interface IClassService
    {
        List<Class> GetAll();
        Class GetDetail(string id);
        void Create(Class param);
        void Update(Class param);
        void Delete(string id);
    }
}
