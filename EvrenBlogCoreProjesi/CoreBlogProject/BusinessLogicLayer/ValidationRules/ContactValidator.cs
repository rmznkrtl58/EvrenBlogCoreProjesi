using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<WebContact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lüften Konu Giriniz!");
            RuleFor(x => x.Subject).MaximumLength(25).WithMessage("Lüften En Fazla 25 karakter Giriniz!");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Lüften Adınızı Soyadınızı Giriniz!");
            RuleFor(x => x.NameSurname).MaximumLength(40).WithMessage("Lüften En Fazla 40 karakter Giriniz!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lüften E-posta Giriniz!");
            RuleFor(x => x.Mail).MaximumLength(40).WithMessage("Lüften En Fazla 40 karakter Giriniz!");
            RuleFor(x => x.ContactContent).NotEmpty().WithMessage("Lüften Mesajınızı Giriniz!");
            RuleFor(x => x.ContactContent).MinimumLength(30).WithMessage("Lüften En Az 30 Karakter Giriniz!");
        }
    }
}
