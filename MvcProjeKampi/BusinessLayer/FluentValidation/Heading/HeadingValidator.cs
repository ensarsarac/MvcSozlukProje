using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class HeadingValidator: AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Başlık adı boş bırakılamaz.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori alanı boş bırakılamaz");
            //RuleFor(x => x.WriterID).NotEmpty().WithMessage("Yazar Alanı boş bırakılamaz.");
        }
    }
}
