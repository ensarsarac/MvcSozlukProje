using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface MessageService: GenericService<Message>
    {
        List<Message> GetSendBox(string mail);
        List<Message> GetInBox(string mail);
    }
}
