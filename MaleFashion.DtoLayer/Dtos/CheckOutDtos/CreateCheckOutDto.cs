using MaleFashion.DtoLayer.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.CheckOutDtos
{
    public class CreateCheckOutDto
    {
        public int BasketId { get; set; }
        public ResultBasketDto ResultBasketDto { get; set; }
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
