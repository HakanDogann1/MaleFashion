using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class CheckOut
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Country { get; set; }
        public String AddressStreet { get; set; }
        public String AddressDetail { get; set; }
        public String City { get; set; }
        public String PostCode { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Note { get; set; }
    }
}
