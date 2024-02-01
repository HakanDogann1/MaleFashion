using MaleFashion.DtoLayer.Dtos.HeaderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IHeaderService:IGenericService<ResultHeaderDto,UpdateHeaderDto,CreateHeaderDto>
    {
    }
}
