using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        public string Name { get; private set; }


        // GET: Courses
        //private MyDBContext Context { get; }
        private MyDBContext db = new MyDBContext();
        public ActionResult Index()
        {
           // Courses courses = new Courses();
           ViewBag.products = db.Courses.ToList();


            return View();
           // return View(courses);
        }

        // GET: Courses/Details/5
        [Authorize(Roles = "Student ,Admin")]
        public string Details(int id)
        {
            Courses c = new Courses();
            string cs="Student details:" + c.CourseId + "Name " + c.Name + "Teacher name= " + c.Teacher.FirstName;

            return cs;
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Courses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
