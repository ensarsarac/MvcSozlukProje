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
    public class AboutManager : AboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Remove(t);
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
