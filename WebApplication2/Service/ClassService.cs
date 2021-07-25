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
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService()
        {
            _classRepository = new ClassRepository();
        }

        public void Create(Class param)
        {
            if (param.ClassName != null)
            {
                _classRepository.Create(param);
            }
        }

        public void Delete(string id)
        {
            _classRepository.Delete(id);
        }

        public List<Class> GetAll()
        {
            return _classRepository.GetAll();
        }

        public Class GetDetail(string id)
        {
            var detail = _classRepository.GetDetail(id);
            return detail;
        }

        public void Update(Class param)
        {
            _classRepository.Update(param);
        }
    }
}