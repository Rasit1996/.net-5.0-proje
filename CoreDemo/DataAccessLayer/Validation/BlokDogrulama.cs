using EntityLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Validation
{
    public class BlokDogrulama:AbstractValidator<Blok>
    {
        public BlokDogrulama()
        {
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("Boş Geçilemez!");
            RuleFor(x => x.İcerik).NotEmpty().WithMessage("Boş Geçilemez!");

        }
    }
}
