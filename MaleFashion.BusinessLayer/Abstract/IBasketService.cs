using MaleFashion.DtoLayer.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<ResultBasketDto,UpdateBasketDto,CreateBasketDto>
    {
    }
}
