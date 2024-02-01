using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class Color
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public List<ProductRegister> ProductRegisters { get; set; }
    }
}
