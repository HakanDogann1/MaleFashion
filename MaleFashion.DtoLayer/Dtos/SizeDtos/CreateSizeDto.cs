using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.SizeDtos
{
    public class CreateSizeDto
    {
        public String Name { get; set; }
        public int CategoryId { get; set; }
        public ResultCategoryDto ResultCategoryDto { get; set; }
    }
}
