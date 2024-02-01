using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class CouponCode
    {
        public int Id { get; set; }
        public String Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ValidityDay { get; set; }
        public DateTime EndDate { get; set; }
    }
}
