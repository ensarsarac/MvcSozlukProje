using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int ID { get; set; }
        [StringLength(1000,ErrorMessage ="En fazla 1000 karakter girebilirsiniz.")]
        public string Details1 { get; set; }
        [StringLength(1000, ErrorMessage = "En fazla 1000 karakter girebilirsiniz.")]
        public string Details2 { get; set; }
        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string Image{ get; set; }

        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string Image2{ get; set; }
    }
}
