using FluentValidation;
using MaleFashion.DtoLayer.Dtos.SocialMediaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.SocialMediaValidations
{
    public class UpdateSocialMediaValidator:AbstractValidator<UpdateSocialMediaDto>
    {
        public UpdateSocialMediaValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon alanı boş bırakılamaz.");
            RuleFor(x => x.SocialMediaTag).NotEmpty().WithMessage("Tag alanı boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url alanı boş bırakılamaz.");
        }
    }
}
