using FluentValidation;
using MaleFashion.DtoLayer.Dtos.HeaderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.HeaderValidations
{
    public class UpdateHeaderValidator:AbstractValidator<UpdateHeaderDto>
    {
        public UpdateHeaderValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş olamaz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık alanı en az 5 karakter olmalıdır.");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt başlık alanı boş olamaz");
            RuleFor(x => x.SubTitle).MinimumLength(5).WithMessage("Alt başlık alanı en az 5 karakter olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İçerik alanı boş olamaz");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("İçerik alanı en az 5 karakter olmalıdır.");
        }
    }
}
