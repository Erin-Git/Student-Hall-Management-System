using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHallManagement.Database;
using StudentHallManagement.Models;
using StudentHallManagement.ViewModels;

namespace StudentHallManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBClass dbc;
        public HomeController(DBClass DBC)
        {
            dbc = DBC;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserViewModel userinfo)
        {
            var u1 = dbc.User.Where(q => q.UserID == userinfo.useridVM && q.Password == userinfo.passwordVM && q.UserRoleID==1).FirstOrDefault();
            if (u1 != null)
            {
                HttpContext.Session.SetString("UserID", u1.UserID.ToString());
                HttpContext.Session.SetString("UserRoleID", u1.UserRoleID.ToString());
                return RedirectToAction("Supervisor", "Supervisor");
            }
            else if(u1==null)
            {
                var u2 = dbc.User.Where(q => q.UserID == userinfo.useridVM && q.Password == userinfo.passwordVM && q.UserRoleID == 2).FirstOrDefault();
                if (u2 != null)
                {
                    HttpContext.Session.SetString("UserID", u2.UserID.ToString());
                    HttpContext.Session.SetString("UserRoleID", u2.UserRoleID.ToString());
                    return RedirectToAction("Index", "Student");
                }
                else
                    ViewBag.errmsg = "Invalid UserID or Password!";
                    return View();

                 }
            ModelState.Clear();
                return View();
          
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
