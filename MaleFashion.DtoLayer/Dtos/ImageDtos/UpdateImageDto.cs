using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.ImageDtos
{
    public class UpdateImageDto
    {
        public int Id { get; set; }
        public String ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public ResultCategoryDto ResultCategoryDto { get; set; }
    }
}
