using FluentValidation;
using MaleFashion.DtoLayer.Dtos.SizeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.SizeValidations
{
    public class CreateSizeValidator:AbstractValidator<CreateSizeDto>
    {
        public CreateSizeValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Beden alanı boş bırakılamaz.");
        }
    }
}
