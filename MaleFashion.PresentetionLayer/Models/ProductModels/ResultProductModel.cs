using MaleFashion.PresentetionLayer.Models.CategoryModels;

namespace MaleFashion.PresentetionLayer.Models.ProductModels
{
    public class ResultProductModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public int Star { get; set; }
        public double NewPrice { get; set; }
        public double OldPrice { get; set; }
        public String Description { get; set; }
        public String SKU { get; set; }
        public int CategoryId { get; set; }
        public ResultCategoryModel ResultCategoryModel { get; set; }
        public String ProductDescription { get; set; }
        public String CustomerPreviews { get; set; }
        public String AdditionalInformation { get; set; }
    }
}
