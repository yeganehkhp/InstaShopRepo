using InstaShop.DataLayer;
using InstaShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InstaShop.Web.Security;

namespace InstaShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private ILoginRepository loginRepository;
        InstaShop_DBEntities db = new InstaShop_DBEntities();

        public AccountController()
        {
            loginRepository = new LoginRepository(db);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                login.password = PasswordHelper.EncodePasswordMd5(login.password);
                if (loginRepository.IsExistUser(login.UserName, login.password))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, login.UserName, DateTime.Now, DateTime.Now.AddMinutes(43200), login.RememberMe, login.UserName, FormsAuthentication.FormsCookiePath);
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربری یافت نشد");
                }
            }
            return View(login);
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}