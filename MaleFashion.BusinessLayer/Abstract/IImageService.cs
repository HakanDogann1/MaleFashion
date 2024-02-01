using MaleFashion.DtoLayer.Dtos.ImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IImageService:IGenericService<ResultImageDto,UpdateImageDto,CreateImageDto>
    {
    }
}
