using FluentValidation;
using MaleFashion.DtoLayer.Dtos.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.BlogValidations
{
    public class UpdateBlogValidator:AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş olamaz.");
            RuleFor(x => x.CreatedDate).NotEmpty().WithMessage("Oluşturulma tarihi alanı boş bırakılamaz.");
        }
    }
}
