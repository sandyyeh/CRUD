using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Repository.Interface;

namespace WebApplication2.Controllers
{
    public class CourseSelectionController : Controller
    {
        private IStudentRepository studentRep;
        private IClassRepository classRep;
        private ICourseSelectionRepository courseSelectionRep;
        public CourseSelectionController()
        {
            studentRep = new StudentRepository();
            classRep = new ClassRepository();
            courseSelectionRep = new CourseSelectionRepository();
        }

        public ActionResult Index(string id)
        {
            EditViewModel editViewModel = new EditViewModel();
            List<Student_Class> list = courseSelectionRep.GetAll();
            List<Student_ClassViewModel> result = new List<Student_ClassViewModel>();
            if (!string.IsNullOrEmpty(id))
            {
                editViewModel.Detail = courseSelectionRep.GetDetail(id);
                editViewModel.StudentListItems = courseSelectionRep.GetStudentListItems(id);
                editViewModel.ClassListItems = courseSelectionRep.GetClassCheckboxes(id);
            }
            foreach (var item in list)
            {
                result.Add(new Student_ClassViewModel()
                {
                    StudentId = item.StudentID,
                    ClassName = courseSelectionRep.GetClassName(item.StudentID)
                });
            }

            CourseSelectionViewModel model = new CourseSelectionViewModel()
            {
                EditViewModel = editViewModel,
                Student_ClassList = result,
                StudentId = id
            };
            return View(model);
        }

        public ActionResult Create(string id)
        {
            CreateViewModel model = new CreateViewModel()
            {
                StudentListItems = courseSelectionRep.GetStudentListItems(),
                ClassListItems = courseSelectionRep.GetClassCheckboxes(null)

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string id, string[] selectedClasses)
        {
            try
            {
                courseSelectionRep.Create(id, selectedClasses);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string id)
        {
            return RedirectToAction("Index", "CourseSelection", new { id = id });
        }

        [HttpPost]
        public ActionResult Update(string id, string[] selectedClasses)
        {
            try
            {
                courseSelectionRep.Update(id, selectedClasses);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string id)
        {
            try
            {
                courseSelectionRep.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}