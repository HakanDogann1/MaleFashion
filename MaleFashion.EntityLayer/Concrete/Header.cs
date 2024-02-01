using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class Header
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String SubTitle { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
    }
}
