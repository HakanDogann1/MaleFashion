using MaleFashion.DtoLayer.Dtos.TagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface ITagService : IGenericService<ResultTagDto,UpdateTagDto,CreateTagDto>
    {
    }
}
