using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Name { get; set; }
        [StringLength(200, ErrorMessage = "En fazla 200 karakter girebilirsiniz.")]
        public string Aciklama { get; set; }
        public bool Status{ get; set; }

        public List<Heading> Headings { get; set; }
    }
}
