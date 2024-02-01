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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(MaleFashionContext context) : base(context)
        {
        }
    }
}
