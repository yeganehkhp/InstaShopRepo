using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InstaShop.DataLayer.Models;
using InstaShop.Web.Security;

namespace InstaShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminLoginsController : Controller
    {
        private InstaShop_DBEntities db = new InstaShop_DBEntities();

        // GET: Admin/AdminLogins
        public ActionResult Index()
        {
            var adminAccess = MainAdminAccessCheck();
            if (!adminAccess)
            {
                return Redirect("/");
            }
            return View(db.AdminLogin.ToList());
        }

        // GET: Admin/AdminLogins/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AdminLogin adminLogin = db.AdminLogin.Find(id);
        //    if (adminLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(adminLogin);
        //}

        // GET: Admin/AdminLogins/Create
        public ActionResult Create()
        {
            var adminAccess = MainAdminAccessCheck();
            if (!adminAccess)
            {
                return Redirect("/");
            }
            return View();
        }

        // POST: Admin/AdminLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginID,UserName,Email,Password")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                if (db.AdminLogin.Any(a=>a.UserName==adminLogin.UserName))
                {
                    ModelState.AddModelError("UserName","نام کاربری وارد شده از قبل وجود دارد");
                    return View(adminLogin);
                }
                adminLogin.Password = PasswordHelper.EncodePasswordMd5(adminLogin.Password);
                db.AdminLogin.Add(adminLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminLogin);
        }

        // GET: Admin/AdminLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            var adminAccess = MainAdminAccessCheck();
            if (!adminAccess)
            {
                return Redirect("/");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogin.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }

            adminLogin.Password = null;
            return View(adminLogin);
        }

        // POST: Admin/AdminLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginID,UserName,Email,Password")] AdminLogin adminLogin)
        {
            var admin = db.AdminLogin.Find(adminLogin.LoginID);
            if (admin == null)
            {
                return HttpNotFound();
            }

            ModelState.Remove("Password");

            if (ModelState.IsValid)
            {
                if (adminLogin.Password == null)
                {
                    adminLogin.Password = admin.Password;
                }
                else
                {
                    admin.Password = PasswordHelper.EncodePasswordMd5(adminLogin.Password); ;
                }

                admin.UserName = adminLogin.UserName;
                admin.Email = adminLogin.Email;

                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminLogin);
        }


        // GET: Admin/AdminLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            var adminAccess = MainAdminAccessCheck();
            if (!adminAccess)
            {
                return Redirect("/");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogin.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: Admin/AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogin adminLogin = db.AdminLogin.Find(id);
            db.AdminLogin.Remove(adminLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool MainAdminAccessCheck()
        {
            FormsIdentity identity = (FormsIdentity)User.Identity;
            FormsAuthenticationTicket ticket = identity.Ticket;
            string userName = ticket.UserData;

            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }

            var admin = db.AdminLogin.SingleOrDefault(a => a.UserName == userName);

            if (admin == null)
            {
                return false;
            }

            if (admin.LoginID != 1)
            {
                return false;
            }

            return true;
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
