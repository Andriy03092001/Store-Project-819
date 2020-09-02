using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        //Всіх
        public ActionResult Index()
        {
            return View();
        }
        
        //Лише адміни
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }


        //Просто залогінився
        [Authorize]
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