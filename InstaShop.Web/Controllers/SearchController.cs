using InstaShop.DataLayer;
using InstaShop.DataLayer.Models;
using InstaShop.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaShop.Web.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        InstaShop_DBEntities db = new InstaShop_DBEntities();

        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}