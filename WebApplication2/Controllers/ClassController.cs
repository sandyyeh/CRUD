using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Repository.Interface;

namespace WebApplication2.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        private IClassRepository classRep;
        public ClassController()
        {
            classRep = new ClassRepository();
        }

        public ActionResult Index(string id)
        {
            List<Class> classList = classRep.GetAll();
            Class classDetail = classRep.GetDetail(id);

            ClassViewModel viewModel = new ClassViewModel()
            {
                ClassList = classList,
                ClassDetail = classDetail
            };

            return View(viewModel);
        }


        //GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(Class param)
        {
            try
            {
                classRep.Create(param);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Edit/5
        public ActionResult Edit(string id)
        {
            return RedirectToAction("Index", "Class", new { id = id });
        }

        // POST: Class/Update/5
        [HttpPost]
        public ActionResult Update(Class param)
        {
            try
            {
                classRep.Update(param);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Class/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                classRep.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}