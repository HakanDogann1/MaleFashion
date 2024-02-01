using MaleFashion.DtoLayer.Dtos.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<ResultBlogDto,UpdateBlogDto,CreateBlogDto>
    {
    }
}
