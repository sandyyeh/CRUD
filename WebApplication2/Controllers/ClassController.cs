using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;
using WebApplication2.Service.Interface;

namespace WebApplication2.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        private readonly IClassService _classService;
        private readonly CourseSelectionService _courseService;
        public ClassController()
        {
            _classService = new ClassService();
            _courseService = new CourseSelectionService();
        }

        public ActionResult Index(string id)
        {
            List<Class> classList = _classService.GetAll();
            Class classDetail = _classService.GetDetail(id);

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
                _classService.Create(param);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
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
                _classService.Update(param);
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
                _classService.Delete(id);
                _courseService.UpdateCourse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}