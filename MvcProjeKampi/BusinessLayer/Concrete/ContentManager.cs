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
    public class ContentManager : ContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void TAdd(Content t)
        {
            _contentDal.Insert(t);
        }

        public void TDelete(Content t)
        {
            _contentDal.Remove(t);
        }

        public List<Content> TGetList()
        {
            return _contentDal.GetList();
        }

        public Content TGetById(int id)
        {
            return _contentDal.GetById(id);
        }

        public void TUpdate(Content t)
        {
            _contentDal.Update(t);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.GetList().Where(x => x.WriterID == id && x.Status == true).ToList();
        }
    }
}
