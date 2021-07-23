using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interface
{
    public interface IClassRepository
    {
        List<Class> GetAll();
        Class GetDetail(string id);
        void Create(Class param);
        void Update(Class param);
        void Delete(string id);
    }
}
