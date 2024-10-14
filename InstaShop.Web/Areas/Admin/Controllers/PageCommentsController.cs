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
    public class PageCommentsController : Controller
    {
        private InstaShop_DBEntities db = new InstaShop_DBEntities();

        // GET: Admin/PageComments
        public ActionResult Index()
        {
            var pageComment = db.PageComment.Include(p => p.Page)
                .OrderByDescending(c => c.ShowInPage == null)
                .ThenByDescending(c => c.CreateDate);
            return View(pageComment.ToList());
        }

        // GET: Admin/PageComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageComment.Find(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            return View(pageComment);
        }

        // GET: Admin/PageComments/Create
        public ActionResult Create()
        {
            ViewBag.PageID = new SelectList(db.Page, "PageID", "Name");
            return View();
        }

        // POST: Admin/PageComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,PageID,Name,Email,WebSite,Comment,CreateDate,ShowInPage")] PageComment pageComment)
        {
            if (ModelState.IsValid)
            {
                pageComment.CreateDate = DateTime.Now;
                db.PageComment.Add(pageComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PageID = new SelectList(db.Page, "PageID", "Name", pageComment.PageID);
            return View(pageComment);
        }

        // GET: Admin/PageComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageComment.Find(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageID = new SelectList(db.Page, "PageID", "Username", pageComment.PageID);
            return View(pageComment);
        }

        // POST: Admin/PageComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,PageID,Name,Email,WebSite,Comment,CreateDate,ShowInPage")] PageComment pageComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageID = new SelectList(db.Page, "PageID", "Username", pageComment.PageID);
            return View(pageComment);
        }

        // GET: Admin/PageComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageComment.Find(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            return View(pageComment);
        }

        // POST: Admin/PageComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageComment pageComment = db.PageComment.Find(id);
            db.PageComment.Remove(pageComment);
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
