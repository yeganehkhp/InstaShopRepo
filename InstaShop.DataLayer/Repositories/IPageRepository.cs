using InstaShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<Page> GetAllPage();
        IEnumerable<Page> GetPagesSkipTake(int skip, int take);
        IEnumerable<Page> GetPagesSkipTakeByGroupId(int groupId,int skip, int take);
        IEnumerable<Page> TopPages(int take = 4);
        IEnumerable<Page> PagesInSlider();
        Page TopVisitPage();
        IEnumerable<Page> ShowPageByGroupId(int groupId);
        Page GetPageById(int pageId);
        bool UpdatePage(Page page);
        void Save();
        IEnumerable<Page> SearchPage(string search);
        IEnumerable<Page> LatestPages();
        int PagesCount();
        int PagesCountByGroupId(int groupId);
    }
}
