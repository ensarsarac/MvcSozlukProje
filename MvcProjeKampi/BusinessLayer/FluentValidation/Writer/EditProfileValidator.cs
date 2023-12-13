using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class EditProfileValidator : AbstractValidator<Writer>
    {
        public EditProfileValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Soyad alanı en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title alanı boş bırakılamaz.");

            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında alanı boş bırakılamaz.");
            RuleFor(x => x.About).MinimumLength(20).WithMessage("Hakkında alanı en az 20 karakter olmalıdır.");
            RuleFor(x => x.About).MaximumLength(200).WithMessage("Hakkında alanı en fazla 200 karakter olmalıdır.");

            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim alanı boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.");
        }
    }
}
