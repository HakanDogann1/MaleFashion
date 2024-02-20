using FluentValidation;
using MaleFashion.DtoLayer.Dtos.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.BlogValidations
{
    public class CreateBlogValidator:AbstractValidator<CreateBlogDto>
    {
        public CreateBlogValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık alanı boş olamaz.");
            RuleFor(x=>x.CreatedDate).NotEmpty().WithMessage("Oluşturulma tarihi alanı boş bırakılamaz.");
        }
    }
}
