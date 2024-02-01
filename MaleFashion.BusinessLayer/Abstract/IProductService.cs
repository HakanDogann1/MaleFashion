using MaleFashion.DtoLayer.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<ResultProductDto,UpdateProductDto,CreateProductDto>
    {
    }
}
