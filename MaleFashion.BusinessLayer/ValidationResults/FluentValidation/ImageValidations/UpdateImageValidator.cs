using FluentValidation;
using MaleFashion.DtoLayer.Dtos.ImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.ImageValidations
{
    public class UpdateImageValidator:AbstractValidator<UpdateImageDto>
    {
        public UpdateImageValidator()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url alanı boş bırakılamaz.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori alanı boş bırakılamaz.");
        }
    }
}
