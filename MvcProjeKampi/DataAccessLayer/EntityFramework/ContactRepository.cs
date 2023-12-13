using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class ContactRepository: GenericRepository<Contact>,IContactDal
    {
    }
}
