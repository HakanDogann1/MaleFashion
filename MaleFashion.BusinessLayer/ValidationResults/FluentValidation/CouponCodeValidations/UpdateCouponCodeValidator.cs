using FluentValidation;
using MaleFashion.DtoLayer.Dtos.CouponCodeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.CouponCodeValidations
{
    public class UpdateCouponCodeValidator:AbstractValidator<UpdateCouponCodeDto>
    {
        public UpdateCouponCodeValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Kod alanı boş bırakılamaz.");
            RuleFor(x => x.Code).MinimumLength(3).WithMessage("Kod alanı minimum 3 karakter olmalıdır.");
        }
    }
}
