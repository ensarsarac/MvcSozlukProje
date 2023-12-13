using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Surname { get; set; }

        [StringLength(200, ErrorMessage = "En fazla 200 karakter girebilirsiniz.")]
        public string About { get; set; }

        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz.")]
        public string Image { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Mail { get; set; }
        [StringLength(200, ErrorMessage = "En fazla 200 karakter girebilirsiniz.")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Title{ get; set; }

        public bool Status { get; set; }
        public List<Heading> Headings { get; set; }
        public List<Content> Contents{ get; set; }
    }
}
