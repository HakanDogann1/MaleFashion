using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public String Name { get; set; }
        public String Surname { get; set; }

        public List<Basket> Baskets { get; set; }
    }
}
