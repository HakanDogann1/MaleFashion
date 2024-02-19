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

            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>();

            builder.RegisterType<CouponCodeManager>().As<ICouponCodeService>();
            builder.RegisterType<EfCouponCodeDal>().As<ICouponCodeDal>();

            builder.RegisterType<ImageManager>().As<IImageService>();
            builder.RegisterType<EfImageDal>().As<IImageDal>();

            builder.RegisterType<PartnerManager>().As<IPartnerService>();
            builder.RegisterType<EfPartnerDal>().As<IPartnerDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<SizeManager>().As<ISizeService>();
            builder.RegisterType<EfSizeDal>().As<ISizeDal>();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>();

            builder.RegisterType<TagManager>().As<ITagService>();
            builder.RegisterType<EfTagDal>().As<ITagDal>();

            builder.RegisterType<TeamManager>().As<ITeamService>();
            builder.RegisterType<EfTeamDal>().As<ITeamDal>();
           
        }
    }
}
