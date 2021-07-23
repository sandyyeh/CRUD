using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        DBService dbService = new DBService();
        // GET: Student
        public ActionResult Index(string studentId)
        {
            List<Student> studentList = dbService.GetStudentList();
            Student student = dbService.GetStudent(studentId);

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
        public ActionResult Create(Student model)
        {
            try
            {
                dbService.CreateStudent(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string studentId)
        {
            return RedirectToAction("Index", "Student", new { studentId = studentId });
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Update(Student model)
        {
            try
            {
                dbService.UpdateStudent(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string studentId)
        {
            try
            {
                dbService.DeleteStudent(studentId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
