using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        DBService dbService = new DBService();
        public ActionResult Index(string classId)
        {
            List<Class> classList = dbService.GetClassList();
            Class classDetail = dbService.GetClass(classId);

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
        public ActionResult Create(Class model)
        {
            try
            {
                dbService.CreateClass(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Edit/5
        public ActionResult Edit(string classId)
        {
            return RedirectToAction("Index", "Class", new { classId = classId });
        }

        // POST: Class/Update/5
        [HttpPost]
        public ActionResult Update(Class model)
        {
            try
            {
                dbService.UpdateClass(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Class/Delete/5
        public ActionResult Delete(string classId)
        {
            try
            {
                dbService.DeleteClass(classId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}