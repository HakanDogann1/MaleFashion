using MaleFashion.DtoLayer.Dtos.ProductRegisterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IProductRegisterService:IGenericService<ResultProductRegisterDto,UpdateProductRegisterDto,CreateProductRegisterDto>
    {
    }
}
