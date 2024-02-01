using MaleFashion.DtoLayer.Dtos.ColorDtos;
using MaleFashion.DtoLayer.Dtos.ImageDtos;
using MaleFashion.DtoLayer.Dtos.ProductDtos;
using MaleFashion.DtoLayer.Dtos.SizeDtos;
using MaleFashion.DtoLayer.Dtos.TagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.ProductRegisterDtos
{
    public class UpdateProductRegisterDto
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public ResultProductDto ResultProductDto { get; set; }
        public int? ColorId { get; set; }
        public ResultColorDto ResultColorDto { get; set; }
        public int? SizeId { get; set; }
        public ResultSizeDto ResultSizeDto { get; set; }
        public int? ImageId { get; set; }
        public ResultImageDto ResultImageDto { get; set; }
        public int? TagId { get; set; }
        public ResultTagDto ResultTagDto { get; set; }
        public int Stock { get; set; }
    }
}
