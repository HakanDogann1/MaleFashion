using FluentValidation;
using MaleFashion.DtoLayer.Dtos.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.ColorValidations
{
    public class UpdateColorValidator:AbstractValidator<UpdateColorDto>
    {
        public UpdateColorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Renk alanı boş bırakılamaz.");

        }
    }
}
