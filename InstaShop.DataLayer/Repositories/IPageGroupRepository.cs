using InstaShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer
{
    public interface IPageGroupRepository:IDisposable
    {
        IEnumerable<ShowGroupViewModel> GetGroupsForView();
        IEnumerable<PageGroup> GetAllGroups();
    }
}
