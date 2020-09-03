using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        //Всіх
        public ActionResult Index()
        {

            var UserId = User.Identity.GetUserId(); // Отримали id користувача який зараз залогінений
            if (UserId != null)
            {
                var RoleId = _context.Set<IdentityUserRole>().FirstOrDefault(t => t.UserId == UserId).RoleId;

                var role = _context.Roles.FirstOrDefault(t => t.Id == RoleId);

                if (role.Name == "Admin")
                {
                    return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });
                }
            }
        

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