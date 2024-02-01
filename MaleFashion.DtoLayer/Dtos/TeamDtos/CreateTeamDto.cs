using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.TeamDtos
{
    public class CreateTeamDto
    {
        public String ImageUrl { get; set; }
        public String NameSurname { get; set; }
        public String Department { get; set; }
    }
}
