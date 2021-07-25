using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Repository.Interface;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRep;
        public StudentController()
        {
            studentRep = new StudentRepository();
        }

        // GET: Student
        public ActionResult Index(string id)
        {
            List<Student> studentList = studentRep.GetAll();
            Student student = studentRep.GetDetail(id);

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
                studentRep.Create(param);
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
                studentRep.Update(param);
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
                studentRep.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
