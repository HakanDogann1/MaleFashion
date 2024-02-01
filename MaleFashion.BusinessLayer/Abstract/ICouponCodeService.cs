using MaleFashion.DtoLayer.Dtos.CouponCodeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface ICouponCodeService:IGenericService<ResultCouponCodeDto,UpdateCouponCodeDto,CreateCouponCodeDto>
    {
    }
}
