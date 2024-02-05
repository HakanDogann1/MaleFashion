using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.ColorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : APIControllerExtension
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = await _colorService.TGetAllAsync();
            return TGetResponseAction(value);
        }
        [HttpPost]
        public async Task<IActionResult> AddColor(CreateColorDto createColorDto)
        {
            var value =await _colorService.TAddAsync(createColorDto);
            return TPostResultAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _colorService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpPut]
        public IActionResult UpdateColor(UpdateColorDto updateColorDto)
        {
            var value = _colorService.TUpdate(updateColorDto);
            return TPutResponseAction(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var value = await _colorService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
