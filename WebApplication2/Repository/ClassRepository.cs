using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Repository.Interface;

namespace WebApplication2.Repository
{
    public class ClassRepository : IClassRepository
    {
        modelEntities db = new modelEntities();

        public void Create(Class param)
        {
            Class classDetail = new Class()
            {
                ClassName = param.ClassName,
                Credit = param.Credit,
                Teacher = param.Teacher,
                Location = param.Location
            };

            db.Class.Add(classDetail);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            Class classDetail = new Class();
            classDetail = db.Class.Find(id);

            db.Entry(classDetail).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Class> GetAll()
        {
            IQueryable<Class> result = db.Class;
            return result.ToList();
        }

        public Class GetDetail(string id)
        {
            Class result = this.GetAll().Where(o => o.ClassID == id).FirstOrDefault();
            return result;
        }

        public void Update(Class param)
        {
            Class classDetail = new Class();
            classDetail = db.Class.Find(param.ClassID);
            classDetail.ClassName = param.ClassName;
            classDetail.Credit = param.Credit;
            classDetail.Teacher = param.Teacher;
            classDetail.Location = param.Location;

            db.Entry(classDetail).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}