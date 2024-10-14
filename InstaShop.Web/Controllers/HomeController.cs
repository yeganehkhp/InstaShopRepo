using InstaShop.DataLayer;
using InstaShop.DataLayer.Models;
using InstaShop.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaShop.Web.Controllers
{
    public class HomeController : Controller
    {
        InstaShop_DBEntities db = new InstaShop_DBEntities();
        private IPageRepository pageRepository;

        public HomeController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(pageRepository.PagesInSlider());
        }

        [Route("AddMyPage")]
        public ActionResult AddMyPage()
        {
            return View();
        }

        [HttpPost]
        [Route("UploadImage")]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string vImagePath = String.Empty;
            string vMessage = String.Empty;
            string vFilePath = String.Empty;
            string vOutput = String.Empty;
            try
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var vFileName = DateTime.Now.ToString("yyyyMMdd-HHMMssff") +
                                    Path.GetExtension(upload.FileName).ToLower();
                    var vFolderPath = Server.MapPath("/CKEditorImages/");
                    if (!Directory.Exists(vFolderPath))
                    {
                        Directory.CreateDirectory(vFolderPath);
                    }
                    vFilePath = Path.Combine(vFolderPath, vFileName);
                    upload.SaveAs(vFilePath);
                    vImagePath = Url.Content("/CKEditorImages/" + vFileName);
                    vMessage = "تصویر با موفقیت ذخیره شد";
                }
            }
            catch
            {
                vMessage = "خطا در آپلود تصویر";
            }

            vOutput = @"<html><body><script type='text/javascript'>
                window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", '" + vImagePath + "', '" + vMessage + @"');
                </script></body></html>";

            return Content(vOutput);
        }
    }
}