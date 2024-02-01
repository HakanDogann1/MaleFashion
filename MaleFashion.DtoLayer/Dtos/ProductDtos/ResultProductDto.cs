using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public int Star { get; set; }
        public double NewPrice { get; set; }
        public double OldPrice { get; set; }
        public String Description { get; set; }
        public String SKU { get; set; }
        public int CategoryId { get; set; }
        public ResultCategoryDto ResultCategoryDto { get; set; }
        public String ProductDescription { get; set; }
        public String CustomerPreviews { get; set; }
        public String AdditionalInformation { get; set; }
    }
}
