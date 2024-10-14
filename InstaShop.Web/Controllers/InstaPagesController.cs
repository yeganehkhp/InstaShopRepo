using InstaShop.DataLayer;
using InstaShop.DataLayer.Models;
using InstaShop.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace InstaShop.Web.Controllers
{
    public class InstaPagesController : Controller
    {
        InstaShop_DBEntities db = new InstaShop_DBEntities();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;

        public InstaPagesController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
        }

        // GET: Pages
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupsForView());
        }

        public ActionResult TopPages()
        {
            var topPagesList = pageRepository.TopPages(4).ToList();
            return PartialView(topPagesList);
        }

        [Route("Archive/Page/{pageId}")]
        public ActionResult ArchivePages(int pageId)
        {
            int skip = (pageId - 1) * 10;
            int count = pageRepository.PagesCount();

            ViewBag.PageID = pageId;
            ViewBag.PageCount = count / 10;
            ViewBag.PagingRout = $"/Archive/Page/";

            return View(pageRepository.GetPagesSkipTake(skip, 10));
        }

        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }

        public ActionResult ShowGroupsInFooter()
        {
            return PartialView(pageGroupRepository.GetAllGroups());
        }

        [Route("Group/{id}/{title}/Page/{pageId}")]
        public ActionResult ShowGroupsByGroupId(int id, string title, int pageId)
        {
            int skip = (pageId - 1) * 10;
            int count = pageRepository.PagesCountByGroupId(id);

            ViewBag.PageID = pageId;
            ViewBag.PageCount = count / 10;
            ViewBag.name = title;
            ViewBag.PagingRout = $"/Group/{id}/{title}/Page";

            ViewBag.name = title;
            return View(pageRepository.GetPagesSkipTakeByGroupId(id, skip, 10));
        }

        [Route("Page/{id}")]
        public ActionResult showPage(int id)
        {
            var page = pageRepository.GetPageById(id);

            if (page == null)
            {
                return HttpNotFound();
            }

            page.Visit += 1;
            pageRepository.UpdatePage(page);
            pageRepository.Save();

            return View(page);
        }

        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            PageComment addcomment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Comment = comment,
                Email = email,
                Name = name,
                ShowInPage = null
            };
            pageCommentRepository.AddComment(addcomment);

            ViewBag.CommentSuccessMessage = "نظر شما با موفقیت ثبت گردید و در صف نمایش قرار گرفت.";
            return PartialView("ShowComments", pageCommentRepository.GetCommentByPageId(id).Where(c => c.ShowInPage == true));
            //return PartialView("_SuccessMessage");
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByPageId(id).Where(c => c.ShowInPage == true));
        }

        public ActionResult TopVisitPage()
        {
            return PartialView(pageRepository.TopVisitPage());
        }

        public ActionResult Search()
        {
            return PartialView();
        }

        public ActionResult LatestPages()
        {
            return PartialView(pageRepository.LatestPages());
        }
    }
}