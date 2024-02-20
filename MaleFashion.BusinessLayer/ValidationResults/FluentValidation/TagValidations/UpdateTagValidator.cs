﻿using FluentValidation;
using MaleFashion.DtoLayer.Dtos.TagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.ValidationResults.FluentValidation.TagValidations
{
    public class UpdateTagValidator:AbstractValidator<UpdateTagDto>
    {
        public UpdateTagValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tag alanı boş bırakılamaz.");
        }
    }
}
