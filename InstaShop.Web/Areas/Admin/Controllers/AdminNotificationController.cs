using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstaShop.DataLayer;
using InstaShop.DataLayer.Models;

namespace InstaShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminNotificationController : Controller
    {
        private IPageCommentRepository _pageCommentRepository;
        private InstaShop_DBEntities _db = new InstaShop_DBEntities();

        public AdminNotificationController()
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