using FluentValidation;
using MaleFashion.DtoLayer.Dtos.PartnerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.PartnerValidations
{
    public class CreatePartnerValidator:AbstractValidator<CreatePartnerDto>
    {
        public CreatePartnerValidator()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Partner resim alanı boş bırakılamaz.");
        }
    }
}
