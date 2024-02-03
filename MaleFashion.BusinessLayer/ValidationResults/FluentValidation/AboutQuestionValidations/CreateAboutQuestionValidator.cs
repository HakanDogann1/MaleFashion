using FluentValidation;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.AboutQuestionValidations
{
    public class CreateAboutQuestionValidator:AbstractValidator<CreateAboutQuestionDto>
    {
        public CreateAboutQuestionValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("İçerik alanı boş bırakılamaz.");
            RuleFor(x=>x.Question).NotEmpty().WithMessage("Soru alanı boş bırakılamaz");
            RuleFor(x => x.Description).MinimumLength(4).WithMessage("İçerik alanı en az 4 karakter olmalıdır.");
        }
    }
}
