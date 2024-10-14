using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstaShop.DataLayer.Models;

namespace InstaShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class PageGroupsController : Controller
    {
        private InstaShop_DBEntities db = new InstaShop_DBEntities();

        // GET: Admin/PageGroups
        public ActionResult Index()
        {
            return View(db.PageGroup.ToList());
        }

        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroup.Find(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                db.PageGroup.Add(pageGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroup.Find(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = db.PageGroup.Find(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return View(pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var comments = db.PageComment.Where(c => c.Page.GroupID == id).ToList();
            db.PageComment.RemoveRange(comments);

            var page = db.Page.Where(p => p.GroupID == id).ToList();
            db.Page.RemoveRange(page);

            PageGroup pageGroup = db.PageGroup.Find(id);
            db.PageGroup.Remove(pageGroup);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
