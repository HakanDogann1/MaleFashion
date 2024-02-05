using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : APIControllerExtension
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = await _categoryService.TGetAllAsync();
            return TGetResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _categoryService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = await _categoryService.TAddAsync(createCategoryDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _categoryService.TUpdate(updateCategoryDto);
            return TPutResponseAction(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value =await _categoryService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
