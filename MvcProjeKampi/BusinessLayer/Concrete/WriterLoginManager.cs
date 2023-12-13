using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterLoginManager : WriterLoginService
    {
        IWriterDal _writeDal;

        public WriterLoginManager(IWriterDal writeDal)
        {
            _writeDal = writeDal;
        }

        public Writer LoginByWriter(string mail, string password)
        {
            return _writeDal.GetList().Where(x => x.Mail == mail && x.Password == password).FirstOrDefault();
        }
    }
}
