using FluentValidation;
using MaleFashion.DtoLayer.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.ProductValidations
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.SKU).NotEmpty().WithMessage("SKU alanı boş bırakılamaz.");
            RuleFor(x => x.OldPrice).NotEmpty().WithMessage("Fiyat alanı boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İçerik alanı boş bırakılamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.");
        }
    }
}
