using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen Başlığı Giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Açıklamayı Giriniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
            RuleFor(x => x.Description).MaximumLength(300).WithMessage("Lütfen En Fazla 300 Karakter Giriniz");
        }
    }
}
