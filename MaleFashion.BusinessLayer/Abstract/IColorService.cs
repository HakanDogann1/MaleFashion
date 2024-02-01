using MaleFashion.DtoLayer.Dtos.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IColorService:IGenericService<ResultColorDto,UpdateColorDto,CreateColorDto>
    {
    }
}
