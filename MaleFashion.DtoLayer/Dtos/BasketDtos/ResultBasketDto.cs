using MaleFashion.DtoLayer.Dtos.ProductDtos;
using MaleFashion.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ProductId { get; set; }
        public ResultProductDto ResultProductDto { get; set; }
        public int Quentity { get; set; }
        public int ProductTotal { get; set; }
        public double SubTotal { get; set; }
        public double TotalPrice { get; set; }
    }
}
