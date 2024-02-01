using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<ResultCategoryDto,UpdateCategoryDto,CreateCategoryDto>
    {
    }
}
