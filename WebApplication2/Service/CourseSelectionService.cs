using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Repository.Interface;
using WebApplication2.Service.Interface;

namespace WebApplication2.Service
{
    public class CourseSelectionService : ICourseSelectionService
    {
        private readonly ICourseSelectionRepository _courseRepository;

        public CourseSelectionService()
        {
            _courseRepository = new CourseSelectionRepository();
        }

        public void Create(string id, string[] selectedClasses)
        {
            _courseRepository.Create(id, selectedClasses);
        }

        public void Delete(string id)
        {
            _courseRepository.Delete(id);
        }

        public List<Student_Class> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public List<ClassCheckboxItem> GetClassCheckboxes(string id)
        {
            return _courseRepository.GetClassCheckboxes(id);
        }

        public List<SelectListItem> GetClassListItems(string id)
        {
            return _courseRepository.GetClassListItems(id);
        }

        public string GetClassName(string id)
        {
            return _courseRepository.GetClassName(id);
        }

        public Student_Class GetDetail(string id)
        {
            return _courseRepository.GetDetail(id);
        }

        public List<SelectListItem> GetStudentListItems(string id)
        {
            return _courseRepository.GetStudentListItems(id);
        }

        public List<SelectListItem> GetStudentListItems()
        {
            return _courseRepository.GetStudentListItems();
        }

        public void Update(string id, string[] selectedClasses)
        {
            _courseRepository.Update(id, selectedClasses);
        }

        public void UpdateCourse(string classId)
        {
            _courseRepository.UpdateCourse(classId);
        }
    }
}