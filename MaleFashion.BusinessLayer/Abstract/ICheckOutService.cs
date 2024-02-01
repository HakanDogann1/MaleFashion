using MaleFashion.DtoLayer.Dtos.CheckOutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface ICheckOutService:IGenericService<ResultCheckOutDto,UpdateCheckOutDto,CreateCheckOutDto>
    {
    }
}
