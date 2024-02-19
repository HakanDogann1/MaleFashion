using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.TagDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : APIControllerExtension
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _tagService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateTagDto createTagDto)
        {
            var value = await _tagService.TAddAsync(createTagDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateTagDto updateTagDto)
        {
            var value = _tagService.TUpdate(updateTagDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _tagService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _tagService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
