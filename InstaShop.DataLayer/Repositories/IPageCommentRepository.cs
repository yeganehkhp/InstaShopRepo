using InstaShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetCommentByPageId(int PageId);
        bool AddComment(PageComment comment);
        int GetNewCommentsCount();
    }
}
