using EntityLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Validation
{
	public class YazarDogrulama:AbstractValidator<Yazar>
	{
        public YazarDogrulama()
        {
            RuleFor(x => x.Adi).NotEmpty().WithMessage("Boş geçilemez!");
            RuleFor(x => x.Soyadi).NotEmpty().WithMessage("Boş Geçilemez!");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.Sifre).Matches(@"[a-z]").WithMessage("En az bir küçük harf içermelidir!");
            RuleFor(x => x.Sifre).Matches(@"[A-Z]").WithMessage("En az bir büyük harf içermelidir!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Boş geçilemez!");
            RuleFor(x => x.Hakkinda).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}
