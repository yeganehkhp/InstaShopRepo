using InstaShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaShop.DataLayer
{
    public class LoginRepository : ILoginRepository
    {

        private InstaShop_DBEntities db;

        public LoginRepository(InstaShop_DBEntities context)
        {
            db = context;
        }

        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogin.Any(u => u.UserName == username && u.Password == password);
        }
    }
}
