using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseFirstProject.Entities;

namespace DatabaseFirstProject.Controllers
{

    public class UserController : Controller
    {
        BookEntities _db = new BookEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user)
        {
            var tryLogin = _db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            if (tryLogin != null)
            {
                Session["Id"] = user.Id.ToString();
                Session["UserName"] = user.UserName.ToString();
                return RedirectToAction("Index", "Posts");
            }
            else
            {
                ViewBag.Login = "تأكد من كلمة المرور واسم المستخدم";
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "تأكد من البيانات المدخلة";
            }
            try
            {
                var compare = _db.Users.Where(m => m.UserName == user.UserName).Count();
                while (compare > 0)
                {
                    ViewBag.Message = "هذا المستخدم موجود مسبقاً";
                    return View();
                }
                _db.Users.Add(user);
                _db.SaveChanges();
                ViewBag.Message = "تم تسجيلك بنجاح";
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "هناك خطأ ما";
                return View();
            }
        }
    }
}