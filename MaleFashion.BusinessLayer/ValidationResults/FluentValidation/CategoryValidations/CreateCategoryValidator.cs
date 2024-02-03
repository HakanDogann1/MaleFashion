using FluentValidation;
using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.CategoryValidations
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Kategori adı alanı boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Kategori resim alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı alanı minimum 2 karakter olmalıdır.");

        }
    }
}
