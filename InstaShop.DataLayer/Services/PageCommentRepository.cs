using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaShop.DataLayer.Models;

namespace InstaShop.DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private InstaShop_DBEntities db;
        public PageCommentRepository(InstaShop_DBEntities context)
        {
            db = context;
        }

        public IEnumerable<PageComment> GetCommentByPageId(int pageId)
        {
            return db.PageComment.Where(c => c.PageID == pageId);
        }

        public bool AddComment(PageComment comment)
        {
            try
            {
                db.PageComment.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int GetNewCommentsCount()
        {
            return db.PageComment.Count(c => c.ShowInPage == null);
        }
    }
}
