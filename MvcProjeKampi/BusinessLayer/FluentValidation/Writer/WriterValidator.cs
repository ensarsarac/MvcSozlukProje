using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen ad alanını doldurunuz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyad alanını doldurunuz.");
            RuleFor(x => x.About).NotEmpty().WithMessage("Lütfen hakkında alanını doldurunuz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen ünvan alanını doldurunuz.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre alanını doldurunuz.");
            RuleFor(x => x.About).MinimumLength(10).WithMessage("Lütfen en az 10 karakter giriniz.");
            RuleFor(x => x.About).MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter giriniz.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen mail alanını doldurunuz.");
        }
    }
}
