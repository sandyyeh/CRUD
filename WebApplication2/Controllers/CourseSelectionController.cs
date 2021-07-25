using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class CourseSelectionController : Controller
    {
        private readonly CourseSelectionService _courseService;
        public CourseSelectionController()
        {
            _courseService = new CourseSelectionService();
        }

        public ActionResult Index(string id)
        {
            EditViewModel editViewModel = new EditViewModel();
            List<Student_Class> list = _courseService.GetAll();
            List<Student_ClassViewModel> result = new List<Student_ClassViewModel>();
            if (!string.IsNullOrEmpty(id))
            {
                editViewModel.Detail = _courseService.GetDetail(id);
                editViewModel.StudentListItems = _courseService.GetStudentListItems(id);
                editViewModel.ClassListItems = _courseService.GetClassCheckboxes(id);
            }
            foreach (var item in list)
            {
                result.Add(new Student_ClassViewModel()
                {
                    StudentId = item.StudentID,
                    ClassName = _courseService.GetClassName(item.StudentID)
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
                StudentListItems = _courseService.GetStudentListItems(),
                ClassListItems = _courseService.GetClassCheckboxes(null)

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string id, string[] selectedClasses)
        {
            try
            {
                _courseService.Create(id, selectedClasses);
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
                _courseService.Update(id, selectedClasses);
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