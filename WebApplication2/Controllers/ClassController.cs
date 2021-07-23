using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        DBService dbService = new DBService();
        public ActionResult Index()
        {
            List<Class> classList = dbService.GetClassList();
            return View(classList);
        }

        //// GET: Class/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            Class classDetail = dbService.GetClass(id);
            return View(classDetail);
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(Class model)
        {
            try
            {

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}