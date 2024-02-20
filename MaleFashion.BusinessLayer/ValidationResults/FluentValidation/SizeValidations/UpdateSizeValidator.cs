using FluentValidation;
using MaleFashion.DtoLayer.Dtos.SizeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.SizeValidations
{
    public class UpdateSizeValidator:AbstractValidator<UpdateSizeDto>
    {
        public UpdateSizeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Beden alanı boş bırakılamaz.");
        }
    }
}
