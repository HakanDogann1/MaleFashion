using Autofac;
using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Concrate;
using MaleFashion.BusinessLayer.ValidationResults.FluentValidation.HeaderValidations;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DtoLayer.Dtos.HeaderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.DependencyResolves.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutQuestionManager>().As<IAboutQuestionService>();
            builder.RegisterType<EfAboutQuestionDal>().As<IAboutQuestionDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();

            builder.RegisterType<HeaderManager>().As<IHeaderService>();
            builder.RegisterType<EfHeaderDal>().As<IHeaderDal>();

           
        }
    }
}
