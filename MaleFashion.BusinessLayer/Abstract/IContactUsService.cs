using MaleFashion.DtoLayer.Dtos.ContactUsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IContactUsService:IGenericService<ResultContactUsDto,UpdateContactUsDto,CreateContactUsDto>
    {
    }
}
