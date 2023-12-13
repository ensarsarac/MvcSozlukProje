using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int ID { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }

        public bool Status { get; set; }
        public bool IsRead { get; set; }
    }
}
