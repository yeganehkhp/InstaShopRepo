using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstaShop.DataLayer.Models;
using InstaShop.Web;

namespace InstaShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private InstaShop_DBEntities db = new InstaShop_DBEntities();

        // GET: Admin/Pages
        public ActionResult Index()
        {
            var page = db.Page.Include(p => p.PageGroup);
            return View(page.ToList());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Page.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.PageGroup, "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Username,Name,ProfileImage," +
            "Phone,Bio,Description,ShowInSlider,Visit,Tags,CreateDate")] Page page,HttpPostedFileBase imUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;

                if (imUp != null)
                {
                    page.ProfileImage = Guid.NewGuid() + Path.GetExtension(imUp.FileName);
                    imUp.SaveAs(Server.MapPath("/ProfileImage/" + page.ProfileImage));
                }

                db.Page.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.PageGroup, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Page.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.PageGroup, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Username,Name,ProfileImage,Phone,Bio,Description,ShowInSlider,Visit,Tags,CreateDate")] Page page,HttpPostedFileBase imUp)
        {
            if (ModelState.IsValid)
            {
                if (imUp != null)
                {
                    if (page.ProfileImage != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/ProfileImage/" + page.ProfileImage));
                    }

                    page.ProfileImage = Guid.NewGuid() + Path.GetExtension(imUp.FileName);
                    imUp.SaveAs(Server.MapPath("/ProfileImage/" + page.ProfileImage));
                }

                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.PageGroup, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Page.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }

            if (page.ProfileImage != null)
            {
                System.IO.File.Delete(Server.MapPath("/ProfileImage/" + page.ProfileImage));
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var comments = db.PageComment.Where(c => c.PageID == id).ToList();
            db.PageComment.RemoveRange(comments);

            Page page = db.Page.Find(id);
            db.Page.Remove(page);

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
