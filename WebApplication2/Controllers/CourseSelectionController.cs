using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class CourseSelectionController : Controller
    {
        DBService dbService = new DBService();
        public ActionResult Index()
        {
           
            //  List<Student> studentList = dbService.GetStudentList();
            //return View(studentList);
            return View();
        }

        public ActionResult Student()
        {
            //List<Student> studentList = dbService.GetStudentList();
            //return View(studentList);
            return View();
        }

        public ActionResult Class()
        {
            //List<Class> classList = dbService.GetClassList();
            //return View(classList);
            return View();
        }
    }
}