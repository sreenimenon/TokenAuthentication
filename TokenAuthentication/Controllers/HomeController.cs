using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TokenAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult login()
        {
            ViewBag.Title = "Login";

            return View();
        }

        public ActionResult ViewPage2()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
