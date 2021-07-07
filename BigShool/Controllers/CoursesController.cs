using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using BigShool.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace BigShool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Create()
        {
            BigSchoolContext Context = new BigSchoolContext();

            Course CouseList = new Course();

            CouseList.ListCategory = Context.Categories.ToList();

            return View(CouseList);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course CreateCourse)
        {
            BigSchoolContext Context = new BigSchoolContext();

            ModelState.Remove("LecturerId");

            if (!ModelState.IsValid)
            {
                CreateCourse.ListCategory = Context.Categories.ToList();
                return View("Create", CreateCourse);
            }

            CreateCourse.LecturerId = User.Identity.GetUserId();

            Context.Courses.Add(CreateCourse);
            Context.SaveChanges();

            return View("Index", "Home");
        }
    }
}