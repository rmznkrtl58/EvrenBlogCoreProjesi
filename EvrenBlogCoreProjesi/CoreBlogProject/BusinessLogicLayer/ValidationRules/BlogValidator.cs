using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Geçilmemeli");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blogun Resim Yolu Boş Geçilmemeli");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blogun İçeriği Boş Geçilmemeli");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blogun Başlığı en az 3 karakter olmalı");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blogun Başlığı en fazla 150 karakter olmalı");
            RuleFor(x => x.BlogImage).MaximumLength(300).WithMessage("Blogun Resim Yolu en fazla 300 karakter olmalı");
            RuleFor(x => x.BlogImage).MinimumLength(20).WithMessage("Blogun Resim Yolu en az 20 karakter olmalı");
            RuleFor(x => x.BlogContent).MinimumLength(150).WithMessage("Blogun İçeriği En Az 300 Karakter olmalı");
        }
    }
}
