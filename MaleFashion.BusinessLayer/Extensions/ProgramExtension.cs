using FluentValidation;
using FluentValidation.AspNetCore;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Concrate;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.AboutQuestionValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.BlogValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.CategoryValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.ColorValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.CouponCodeValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.HeaderValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.ImageValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.PartnerValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.ProductValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.SizeValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.SocialMediaValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.TagValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.TeamValidations;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.Context;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using MaleFashion.DtoLayer.Dtos.BlogDtos;
using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using MaleFashion.DtoLayer.Dtos.ColorDtos;
using MaleFashion.DtoLayer.Dtos.CouponCodeDtos;
using MaleFashion.DtoLayer.Dtos.HeaderDtos;
using MaleFashion.DtoLayer.Dtos.ImageDtos;
using MaleFashion.DtoLayer.Dtos.PartnerDtos;
using MaleFashion.DtoLayer.Dtos.ProductDtos;
using MaleFashion.DtoLayer.Dtos.SizeDtos;
using MaleFashion.DtoLayer.Dtos.SocialMediaDtos;
using MaleFashion.DtoLayer.Dtos.TagDtos;
using MaleFashion.DtoLayer.Dtos.TeamDtos;
using MaleFashion.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Extensions
{
    public static class ProgramExtension
    {
        public static void ProgramConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<MaleFashionContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MaleFashionContext>();

            services.AddSingleton<IValidator<CreateAboutQuestionDto>,CreateAboutQuestionValidator>();
            services.AddSingleton<IValidator<UpdateAboutQuestionDto>,UpdateAboutQuestionValidator>();
            services.AddSingleton<IValidator<CreateCategoryDto>, CreateCategoryValidator>();
            services.AddSingleton<IValidator<UpdateCategoryDto>, UpdateCategoryValidator>();


            services.AddScoped<IValidator<CreateHeaderDto>, CreateHeaderValidator>();
            services.AddScoped<IValidator<UpdateHeaderDto>, UpdateHeaderValidator>();

            services.AddScoped<IValidator<CreateBlogDto>, CreateBlogValidator>();
            services.AddScoped<IValidator<UpdateBlogDto>, UpdateBlogValidator>();

            services.AddScoped<IValidator<CreateColorDto>, CreateColorValidator>();
            services.AddScoped<IValidator<UpdateColorDto>, UpdateColorValidator>();

            services.AddScoped<IValidator<CreateCouponCodeDto>, CreateCouponCodeValidator>();
            services.AddScoped<IValidator<UpdateCouponCodeDto>, UpdateCouponCodeValidator>();

            services.AddScoped<IValidator<CreateImageDto>, CreateImageValidator>();
            services.AddScoped<IValidator<UpdateImageDto>, UpdateImageValidator>();

            services.AddScoped<IValidator<CreatePartnerDto>, CreatePartnerValidator>();
            services.AddScoped<IValidator<UpdatePartnerDto>, UpdatePartnerValidator>();

            services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
            services.AddScoped<IValidator<UpdateProductDto>, UpdateProductValidator>();

            services.AddScoped<IValidator<CreateSizeDto>, CreateSizeValidator>();
            services.AddScoped<IValidator<UpdateSizeDto>, UpdateSizeValidator>();

            services.AddScoped<IValidator<CreateSocialMediaDto>, CreateSocialMediaValidator>();
            services.AddScoped<IValidator<UpdateSocialMediaDto>, UpdateSocialMediaValidator>();

            services.AddScoped<IValidator<CreateTagDto>, CreateTagValidator>();
            services.AddScoped<IValidator<UpdateTagDto>, UpdateTagValidator>();

            services.AddScoped<IValidator<CreateTeamDto>, CreateTeamValidator>();
            services.AddScoped<IValidator<UpdateTeamDto>, UpdateTeamValidator>();

            services.AddScoped<IUow, Uow>();
        }
    }
}
