using InstaShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private InstaShop_DBEntities db;

        public PageGroupRepository(InstaShop_DBEntities context)
        {
            db = context;
        }

        public IEnumerable<ShowGroupViewModel> GetGroupsForView()
        {

            return db.PageGroup.Select(g => new ShowGroupViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Page.Count
            });
        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroup;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
