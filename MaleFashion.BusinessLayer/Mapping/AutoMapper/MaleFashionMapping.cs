using AutoMapper;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using MaleFashion.DtoLayer.Dtos.AboutStatisticDtos;
using MaleFashion.DtoLayer.Dtos.BasketDtos;
using MaleFashion.DtoLayer.Dtos.BlogDtos;
using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using MaleFashion.DtoLayer.Dtos.CheckOutDtos;
using MaleFashion.DtoLayer.Dtos.ColorDtos;
using MaleFashion.DtoLayer.Dtos.CommentDtos;
using MaleFashion.DtoLayer.Dtos.ContactUsDtos;
using MaleFashion.DtoLayer.Dtos.CouponCodeDtos;
using MaleFashion.DtoLayer.Dtos.HeaderDtos;
using MaleFashion.DtoLayer.Dtos.ImageDtos;
using MaleFashion.DtoLayer.Dtos.PartnerDtos;
using MaleFashion.DtoLayer.Dtos.ProductDtos;
using MaleFashion.DtoLayer.Dtos.ProductRegisterDtos;
using MaleFashion.DtoLayer.Dtos.SizeDtos;
using MaleFashion.DtoLayer.Dtos.SocialMediaDtos;
using MaleFashion.DtoLayer.Dtos.TagDtos;
using MaleFashion.DtoLayer.Dtos.TeamDtos;
using MaleFashion.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Mapping.AutoMapper
{
    public class MaleFashionMapping:Profile
    {
        public MaleFashionMapping()
        {
            CreateMap<AboutQuestion,ResultAboutQuestionDto>().ReverseMap();
            CreateMap<AboutQuestion,CreateAboutQuestionDto>().ReverseMap();
            CreateMap<AboutQuestion,UpdateAboutQuestionDto>().ReverseMap();

            CreateMap<AboutStatistic,ResultAboutStatisticDto>().ReverseMap();
            CreateMap<AboutStatistic,UpdateAboutStatisticDto>().ReverseMap();
            CreateMap<AboutStatistic,CreateAboutStatisticDto>().ReverseMap();

            CreateMap<Basket,ResultBasketDto>().ReverseMap();
            CreateMap<Basket,UpdateBasketDto>().ReverseMap();
            CreateMap<Basket,CreateBasketDto>().ReverseMap();

            CreateMap<Blog,CreateBlogDto>().ReverseMap();
            CreateMap<Blog,ResultBlogDto>().ReverseMap();
            CreateMap<Blog,UpdateBlogDto>().ReverseMap();

            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();

            CreateMap<CheckOut,CreateCheckOutDto>().ReverseMap();
            CreateMap<CheckOut,ResultCheckOutDto>().ReverseMap();
            CreateMap<CheckOut,UpdateCheckOutDto>().ReverseMap();

            CreateMap<Color,ResultColorDto>().ReverseMap();
            CreateMap<Color,UpdateColorDto>().ReverseMap();
            CreateMap<Color,CreateColorDto>().ReverseMap();

            CreateMap<Comment,CreateCommentDto>().ReverseMap();
            CreateMap<Comment,ResultCommentDto>().ReverseMap();
            CreateMap<Comment,UpdateCommentDto>().ReverseMap();

            CreateMap<ContactUs,UpdateContactUsDto>().ReverseMap();
            CreateMap<ContactUs,ResultContactUsDto>().ReverseMap();
            CreateMap<ContactUs,CreateContactUsDto>().ReverseMap();

            CreateMap<CouponCode,CreateCouponCodeDto>().ReverseMap();
            CreateMap<CouponCode,ResultCouponCodeDto>().ReverseMap();
            CreateMap<CouponCode,UpdateCouponCodeDto>().ReverseMap();

            CreateMap<Header,UpdateHeaderDto>().ReverseMap();
            CreateMap<Header,ResultHeaderDto>().ReverseMap();
            CreateMap<Header,CreateHeaderDto>().ReverseMap();

            CreateMap<Image,CreateImageDto>().ReverseMap();
            CreateMap<Image,ResultImageDto>().ReverseMap();
            CreateMap<Image,UpdateImageDto>().ReverseMap();

            CreateMap<Partner,UpdatePartnerDto>().ReverseMap();
            CreateMap<Partner,ResultPartnerDto>().ReverseMap();
            CreateMap<Partner,CreatePartnerDto>().ReverseMap();

            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();

            CreateMap<ProductRegister,UpdateProductRegisterDto>().ReverseMap();
            CreateMap<ProductRegister,ResultProductRegisterDto>().ReverseMap();
            CreateMap<ProductRegister,CreateProductRegisterDto>().ReverseMap();

            CreateMap<Size,CreateSizeDto>().ReverseMap();
            CreateMap<Size,UpdateSizeDto>().ReverseMap();
            CreateMap<Size,ResultSizeDto>().ReverseMap();

            CreateMap<SocialMedia,ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,CreateSocialMediaDto>().ReverseMap();

            CreateMap<Tag,CreateTagDto>().ReverseMap();
            CreateMap<Tag,ResultTagDto>().ReverseMap();
            CreateMap<Tag,UpdateTagDto>().ReverseMap();

            CreateMap<Team,UpdateTeamDto>().ReverseMap();
            CreateMap<Team,ResultTeamDto>().ReverseMap();
            CreateMap<Team,CreateTeamDto>().ReverseMap();
        }
    }
}
