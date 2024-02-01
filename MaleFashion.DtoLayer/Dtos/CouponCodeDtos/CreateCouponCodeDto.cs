using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.CouponCodeDtos
{
    public class CreateCouponCodeDto
    {
        public String Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ValidityDay { get; set; }
        public DateTime EndDate { get; set; }
    }
}
