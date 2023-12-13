using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ContentService: GenericService<Content>
    {
        List<Content> GetListByWriter(int id);
    }
}
