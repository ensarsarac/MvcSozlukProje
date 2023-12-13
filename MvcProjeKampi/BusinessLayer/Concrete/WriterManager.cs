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
    public class WriterManager : WriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            _writerDal.Remove(t);
        }

        public List<Writer> TGetList()
        {
            return _writerDal.GetList();
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }

        public Writer TGetWriterByMail(string mail)
        {
            return _writerDal.GetWriterByMail(mail);
        }
    }
}
