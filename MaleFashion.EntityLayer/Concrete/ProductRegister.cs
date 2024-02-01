using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class ProductRegister
    {
        public int Id { get; set; }
        public int? ProductId  { get; set; }
        public Product Product  { get; set; }
        public int? ColorId  { get; set; }
        public Color Color  { get; set; }
        public int? SizeId  { get; set; }
        public Size Size  { get; set; }
        public int? ImageId  { get; set; }
        public Image Image  { get; set; }
        public int? TagId  { get; set; }
        public Tag Tag  { get; set; }
        public int Stock  { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
