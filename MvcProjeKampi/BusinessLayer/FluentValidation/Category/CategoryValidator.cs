using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirisiniz.");
            RuleFor(x=>x.Name).MinimumLength(5).WithMessage("En az 5 karakter girebilirisiniz.");
        }
    }
}
