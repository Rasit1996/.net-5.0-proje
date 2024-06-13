using EntityLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Validation
{
    public class KategoriDogrulama:AbstractValidator<Kategori>
    {
        public KategoriDogrulama()
        {
            RuleFor(x => x.Adi).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Adi).MinimumLength(3).WithMessage("En az 3 harfli olmalıdır!");
        }
    }
}
