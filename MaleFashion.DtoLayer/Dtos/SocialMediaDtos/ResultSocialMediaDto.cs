using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.SocialMediaDtos
{
    public class ResultSocialMediaDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Icon { get; set; }
        public String ImageUrl { get; set; }
        public String SocialMediaTag { get; set; }
    }
}
