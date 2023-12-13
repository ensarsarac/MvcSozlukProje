using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation.Messages
{
    public class AddMessageValidator: AbstractValidator<Message>
    {
        public AddMessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu en az 3 karakter olmak zorunda.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu en fazla 50 karakter olmak zorunda.");
        }
    }
}
