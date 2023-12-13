using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class WriterRepository : GenericRepository<Writer>, IWriterDal
    {
        public Writer GetWriterByMail(string mail)
        {
            Context c = new Context();
            var user = c.Writers.Where(x => x.Mail == mail).FirstOrDefault();
            return user;
        }
    }
}
