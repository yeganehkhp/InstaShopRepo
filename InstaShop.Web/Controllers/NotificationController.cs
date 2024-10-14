using InstaShop.DataLayer.Models;
using InstaShop.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaShop.Web.Controllers
{
    public class NotificationController : Controller
    {
        private IPageCommentRepository _pageCommentRepository;
        private InstaShop_DBEntities _db = new InstaShop_DBEntities();

        public NotificationController()
        {
            _pageCommentRepository = new PageCommentRepository(_db);
        }

        public ActionResult GetNewCommentsCount()
        {
            int newCommentsCount = _pageCommentRepository.GetNewCommentsCount();
            return PartialView("_NewCommentsCount", newCommentsCount);
        }
    }
}