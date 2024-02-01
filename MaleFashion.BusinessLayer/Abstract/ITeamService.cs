using MaleFashion.DtoLayer.Dtos.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface ITeamService:IGenericService<ResultTeamDto,UpdateTeamDto,CreateTeamDto>
    {
    }
}
