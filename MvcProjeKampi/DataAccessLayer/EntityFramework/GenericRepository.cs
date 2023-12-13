using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework.Repository
{
    public class GenericRepository<T> : GenericDal<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            c.Set<T>().Add(t);
            c.SaveChanges();
        }

        public void Remove(T t)
        {
            c.Set<T>().Remove(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            c.SaveChanges();
        }
    }
}
