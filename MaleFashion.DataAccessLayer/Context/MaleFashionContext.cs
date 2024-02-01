using MaleFashion.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DataAccessLayer.Context
{
    public class MaleFashionContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public MaleFashionContext(DbContextOptions<MaleFashionContext> options) : base(options)
        {

        }
        public DbSet<AboutQuestion> AboutQuestions { get; set; }
        public DbSet<AboutStatistic> AboutStatistics { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<CouponCode> CouponCodes { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRegister> ProductRegisters { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x => x.Title).IsRequired();
            builder.Entity<IdentityUserLogin<int>>().HasNoKey();
            builder.Entity<IdentityUserToken<int>>().HasNoKey();
            builder.Entity<IdentityUserRole<int>>().HasNoKey();
            
        }

       

        
    }
}
