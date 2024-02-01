using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.Concrete;
using MaleFashion.DataAccessLayer.Context;
using MaleFashion.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DataAccessLayer.EntityFramework
{
    public class EfAboutQuestionDal : GenericRepository<AboutQuestion>, IAboutQuestionDal
    {
        public EfAboutQuestionDal(MaleFashionContext context) : base(context)
        {
        }
    }
}
