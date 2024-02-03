using FluentValidation;
using FluentValidation.AspNetCore;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Concrete;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.AboutQuestionValidations;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.CategoryValidations;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.Context;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using MaleFashion.DtoLayer.Dtos.CategoryDtos;
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

            services.AddScoped<IAboutQuestionService, AboutQuestionManager>();
            services.AddScoped<IAboutQuestionDal, EfAboutQuestionDal>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogDal>();

            services.AddScoped<IUow, Uow>();
        }
    }
}
