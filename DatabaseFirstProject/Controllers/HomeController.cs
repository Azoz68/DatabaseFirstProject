using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using DatabaseFirstProject.Entities;

namespace DatabaseFirstProject.Controllers
{
    public class HomeController : Controller
    {
        private BookEntities db = new BookEntities();
        public ActionResult Index()
        {
            var result = db.Book.ToList();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var details = db.Book.Where(Book => Book.Id == id).FirstOrDefault();
            return View(details);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.List = db.Auther.ToList();
            return View(db.Book.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "تأكد من البيانات";
                return View(book.Id);
            }
            db.Entry(book).State = EntityState.Modified;
            //db.Book.AddOrUpdate(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}