using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentService _studentService;
        private readonly CourseSelectionService _courseService;
        public StudentController()
        {
            _studentService = new StudentService();
            _courseService = new CourseSelectionService();
        }

        // GET: Student
        public ActionResult Index(string id)
        {
            List<Student> studentList = _studentService.GetAll();
            Student student = _studentService.GetDetail(id);

            StudentViewModel viewModel = new StudentViewModel()
            {
                StudentList = studentList,
                Student = student
            };

            return View(viewModel);
        }


        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student param)
        {
            try
            {
                _studentService.Create(param);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            return RedirectToAction("Index", "Student", new { id = id });
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Update(Student param)
        {
            try
            {
                _studentService.Update(param);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                _studentService.Delete(id);
                _courseService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
