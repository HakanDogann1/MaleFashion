using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class Image
    {
        public int Id { get; set; }
        public String ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ProductRegister> ProductRegisters { get; set; }
    }
}
