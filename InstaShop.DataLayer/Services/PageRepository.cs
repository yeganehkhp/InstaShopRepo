using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaShop.DataLayer.Models;

namespace InstaShop.DataLayer.Services
{
    public class PageRepository : IPageRepository
    {
        private InstaShop_DBEntities db;
        public PageRepository(InstaShop_DBEntities Context)
        {
            db = Context;
        }

        public IEnumerable<Page> GetPagesSkipTake(int skip, int take)
        {
            return db.Page.OrderByDescending(p=>p.CreateDate).Skip(skip).Take(take);
        }

        public IEnumerable<Page> GetPagesSkipTakeByGroupId(int groupId, int skip, int take)
        {
            return db.Page.Where(p => p.GroupID == groupId)
                .OrderByDescending(p => p.CreateDate)
                .Skip(skip)
                .Take(take);
        }

        public IEnumerable<Page> TopPages(int take = 4)
        {
            return db.Page.OrderByDescending(p => p.Visit).Take(take);

        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Page.Where(p => p.ShowInSlider == true).OrderByDescending(p => p.CreateDate);
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.Page;
        }

        public Page TopVisitPage()
        {
            return db.Page.OrderByDescending(p => p.Visit).FirstOrDefault();
        }

        public IEnumerable<Page> ShowPageByGroupId(int groupId)
        {
            return db.Page.Where(p => p.GroupID == groupId);
        }

        public Page GetPageById(int pageId)
        {
            return db.Page.Find(pageId);
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public IEnumerable<Page> SearchPage(string search)
        {
            return
                   db.Page.Where(p =>
                                    p.Name.Contains(search) 
                                    || p.Username.Contains(search) 
                                    || p.Description.Contains(search)
                                    || p.Tags.Contains(search) 
                                    || p.Bio.Contains(search))
                       .Distinct();
        }

        public IEnumerable<Page> LatestPages()
        {
            return db.Page.OrderByDescending(p => p.CreateDate).Take(4);
        }

        public int PagesCount()
        {
            return db.Page.Count();
        }

        public int PagesCountByGroupId(int groupId)
        {
            return db.Page.Count(p => p.GroupID == groupId);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
