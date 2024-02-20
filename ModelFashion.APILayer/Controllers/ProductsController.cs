using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : APIControllerExtension
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = await _productService.TGetAllAsync();
            return TGetResponseAction(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var value = await _productService.TAddAsync(createProductDto);
            return TPostResultAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _productService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _productService.TUpdate(updateProductDto);
            return TPutResponseAction(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await _productService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
