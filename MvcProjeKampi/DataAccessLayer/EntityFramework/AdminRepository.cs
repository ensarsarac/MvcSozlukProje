using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DataAccessLayer.EntityFramework
{
    public class AdminRepository : GenericRepository<About>, AdminDal
    {
        Context c = new Context();
        public Admin Login(string username, string password)
        {
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.UserName == username && x.Password == password);
            return adminuserinfo;
        }
    }
}
