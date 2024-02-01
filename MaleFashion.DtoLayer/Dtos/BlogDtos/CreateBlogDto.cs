using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.BlogDtos
{
    public class CreateBlogDto
    {
        public String Title { get; set; }
        public String AuthorUserName { get; set; }
        public String CreatedDate { get; set; }
        public String Description { get; set; }
    }
}
