using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.HeaderDtos;
using MaleFashion.DtoLayer.Dtos.ImageDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : APIControllerExtension
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _imageService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateImageDto createImageDto)
        {
            var value = await _imageService.TAddAsync(createImageDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateImageDto updateImageDto)
        {
            var value = _imageService.TUpdate(updateImageDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _imageService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _imageService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
