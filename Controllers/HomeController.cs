using ICEP_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICEP_System.Controllers
{
    public class HomeController : Controller
    {
       
            private StoreContextcs _context;
            public HomeController()
            {
                _context = new StoreContextcs();
            }
            public ActionResult Index()
            {
                return View();
            }

            //admin form
            public ActionResult Admin()
            {
                return View();
            }
            //saving details
            [HttpPost]
            public ActionResult Admin(Admin admin)
            {
                admin = new Admin();

                if (!ModelState.IsValid)
                {
                    return View("Admin", admin);
                }

                admin.AdminUserName = "admin";
                admin.AdminPassword = "12345";
                if (admin.AdminUserName != "admin" || admin.AdminPassword != "12345")

                {
                    ModelState.AddModelError("AdminUserName", "UserName or Password is incorrect");
                    return View("Admin", admin);
                }

                Session["AdminUserName"] = admin.AdminUserName;
                return RedirectToAction("Index", "Admin");


            }
            public ActionResult Logout()
            {
                Session.Abandon();
                return RedirectToAction("Admin");
            }
            //==========================Student=============================================================
            public ActionResult Register()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Register(Student student)
            {
                if (!ModelState.IsValid)        //User is in red line because we never created a Users Database
                    return View("Register", student);
                // validate Duplicates
                if (_context.Students.Where(u => u.Email == student.Email).Any())
                {
                    ModelState.AddModelError("Email", "This Email already exists");
                    return View("Register", student);
                }
                if (_context.Students.Where(u => u.StudentNumber == student.StudentNumber).Any())
                {
                    ModelState.AddModelError("StudentNumber", "This Student Number already exists");
                    return View("Register", student);
                }
                _context.Students.Add(student);
                _context.SaveChanges();

                return Content("You have Registered Successfully!!! Go and Login");

            }
            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(LoginFormViewModel user)
            {
                if (!ModelState.IsValid)
                    return View("Login", user);

                var loginUser = _context.Students.Where(u => u.UserName == user.UserName && u.Password == user.Password && u.IsActive == true).FirstOrDefault();
                if (loginUser == null)
                {
                    ModelState.AddModelError("UserName", "UserName or Password is incorrect");
                    return View("Login", user);

                }

                else
                {
                    Session["UserName"] = loginUser.UserName;

                    return RedirectToAction("Index", "Student");
                }
            }
            public ActionResult UserLogout()
            {
                Session.Abandon();
                return RedirectToAction("Login");
            }





        }
}