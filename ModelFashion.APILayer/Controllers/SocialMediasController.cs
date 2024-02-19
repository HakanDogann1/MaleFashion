using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : APIControllerExtension
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _socialMediaService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = await _socialMediaService.TAddAsync(createSocialMediaDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _socialMediaService.TUpdate(updateSocialMediaDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _socialMediaService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _socialMediaService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
