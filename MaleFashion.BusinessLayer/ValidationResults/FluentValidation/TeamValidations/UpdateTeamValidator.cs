using FluentValidation;
using MaleFashion.DtoLayer.Dtos.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.TeamValidations
{
    public class UpdateTeamValidator:AbstractValidator<UpdateTeamDto>
    {
        public UpdateTeamValidator()
        {
            RuleFor(x => x.Department).NotEmpty().WithMessage("Departman alanı boş bırakılamaz.");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad alanı boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim alanı boş bırakılamaz.");
        }
    }
}
