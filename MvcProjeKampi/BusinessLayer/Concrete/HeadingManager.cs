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
    public class HeadingManager : HeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void TAdd(Heading t)
        {
            _headingDal.Insert(t);
        }

        public void TDelete(Heading t)
        {
            _headingDal.Remove(t);
        }

        public List<Heading> TGetList()
        {
            return _headingDal.GetList();
        }

        public Heading TGetById(int id)
        {
            return _headingDal.GetById(id);
        }

        public void TUpdate(Heading t)
        {
            _headingDal.Update(t);
        }

        public List<Heading> GetListByWriter(string UserMail)
        {
            return _headingDal.GetList().Where(x => x.Writer.Mail == UserMail && x.Status == true).ToList();
        }

        public List<Heading> GetListByFilter(string searc)
        {
            if (!String.IsNullOrEmpty(searc))
            {
                return _headingDal.GetList().Where(x => x.Name.ToLower().Contains(searc)).ToList();

            }
            else
            {
                return _headingDal.GetList();
            }
        }
    }
}
