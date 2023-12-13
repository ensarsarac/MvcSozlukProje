﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string UserName { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Mail { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Subject { get; set; }

        public string Message { get; set; }
        public DateTime Date{ get; set; }
        public bool IsRead{ get; set; }
    }
}
