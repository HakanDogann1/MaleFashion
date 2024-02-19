using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.SizeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : APIControllerExtension
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _sizeService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateSizeDto createSizeDto)
        {
            var value = await _sizeService.TAddAsync(createSizeDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateSizeDto updateSizeDto)
        {
            var value = _sizeService.TUpdate(updateSizeDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _sizeService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _sizeService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
