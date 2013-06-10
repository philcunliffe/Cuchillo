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
        //private KnifeStoreContext db = new KnifeStoreContext();
        private AccessClasses ac = new AccessClasses(new KnifeStoreContext());

        //
        // GET: /Products/

        [Authorize(Roles="Administrator")]
        public ActionResult Index()
        {
            return View(ac.db.Products.ToList());
        }


        public ActionResult PreviousDeals(string Message = "")
        {
            ViewBag.Message = Message;

            ViewBag.RequestedIds = ac.GetUserRequestsFromId(WebSecurity.CurrentUserId);

            var productsOrderedByDate = ac.db.Products.SqlQuery("Select * from dbo.Products p Order by p.DateAdded");
            return View(productsOrderedByDate);
        }

        [Authorize]
        public ActionResult Request(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("PreviousDeals", new { Message = "<span class=\"error\">Sorry! There was an error</span>" });
            }

            Subscription toAdd = new Subscription { ProductId = id, UserProfileId = WebSecurity.CurrentUserId };
            ac.db.Subscriptions.Add(toAdd);
            ac.db.SaveChanges();

            return RedirectToAction("PreviousDeals", new { Message = "Successfully requested item " + id});
        }

        [Authorize]
        public ActionResult Unrequest(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("PreviousDeals", new { Message = "<span class=\"error\">Sorry! There was an error</span>" });
            }
            var temp = ac.GetSubcriptionFromIds(id, WebSecurity.CurrentUserId);
            ac.db.Subscriptions.Remove(temp);
            ac.db.SaveChanges();

            return RedirectToAction("PreviousDeals", new { Message = "No longer requesting item " + id });
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = ac.db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Products/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ac.db.Products.Add(product);
                ac.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Product product = ac.db.Products.Find(id);
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
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                ac.db.Entry(product).State = EntityState.Modified;
                ac.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Product product = ac.db.Products.Find(id);
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
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = ac.db.Products.Find(id);
            ac.db.Products.Remove(product);
            ac.db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ac.db.Dispose();
            base.Dispose(disposing);
        }
    }
}