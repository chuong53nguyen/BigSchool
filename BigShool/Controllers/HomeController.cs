using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using BigShool.Models;
using Microsoft.AspNet.Identity;


namespace BigShool.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            BigSchoolContext Context = new BigSchoolContext();
            UserContext Users = new UserContext();

            var ListCourse = Context.Courses
                .Where(Course => Course.DateTime > DateTime.Now)
                .OrderBy(Course => Course.DateTime).ToList();

            var Loop = 0;
            var UserID = User.Identity.GetUserId();
            var UserInfo = Users.AspNetUsers.Where(CurrentUser => CurrentUser.Id == UserID).ToList();

            while (Loop < ListCourse.Count())
            {
                ListCourse[Loop].Name = UserInfo[0].UserName;
                Loop++;
            }

            return View(ListCourse);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}