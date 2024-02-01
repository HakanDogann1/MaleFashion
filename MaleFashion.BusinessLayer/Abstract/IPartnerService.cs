using MaleFashion.DtoLayer.Dtos.PartnerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IPartnerService:IGenericService<ResultPartnerDto,UpdatePartnerDto,CreatePartnerDto>
    {
    }
}
