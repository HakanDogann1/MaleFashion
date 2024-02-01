using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class Basket
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quentity { get; set; }
        public int ProductTotal { get; set; }
        public double SubTotal { get; set; }
        public double TotalPrice { get; set; }
    }
}
