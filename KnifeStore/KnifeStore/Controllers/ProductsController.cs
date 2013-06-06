using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnifeStore.Models;
using KnifeStore.DataAccess;
using WebMatrix.WebData;
using KnifeStore.Filters;

namespace KnifeStore.Controllers
{
    public class ProductsController : Controller
    {
        private KnifeStoreContext db = new KnifeStoreContext();
        private AccessClasses ac = new AccessClasses(new KnifeStoreContext());

        //
        // GET: /Products/

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }


        public ActionResult PreviousDeals(string Message = "")
        {
            ViewBag.Message = Message;

            ViewBag.RequestedIds = ac.GetUserRequestsFromId(WebSecurity.CurrentUserId);

            var productsOrderedByDate = db.Products.SqlQuery("Select * from dbo.Products p Order by p.DateAdded");
            return View(productsOrderedByDate);
        }

        public ActionResult Request(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("PreviousDeals", new { Message = "<span class=\"error\">Sorry! There was an error</span>" });
            }

            Subscription toAdd = new Subscription { ProductId = id, UserProfileId = WebSecurity.CurrentUserId };
            db.Subscriptions.Add(toAdd);
            db.SaveChanges();

            return RedirectToAction("PreviousDeals", new { Message = "Successfully subscribed to item " + id});
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}