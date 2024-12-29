using CategoryProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryProductManagement.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var catagories = db.categories.ToList();
            return View(catagories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var catogories=db.categories.FirstOrDefault(s=>s.CategoryId == id);
            if(catogories == null)
            {
                return HttpNotFound();
            }
            return View(catogories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
               db.categories.Add(category);
                db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = db.categories.Find(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var catogory=db.categories.Find(id);
            if (catogory == null)
            {
                return HttpNotFound();
            }
            return View(catogory);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var catory=db.categories.Find(id);
            if(catory != null)
            {
                db.categories.Remove(catory);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
