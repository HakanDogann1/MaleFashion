using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.BlogDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : APIControllerExtension
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = await _blogService.TGetAllAsync();
            return TGetResponseAction(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var value = await _blogService.TAddAsync(createBlogDto);
            return TPostResultAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _blogService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var value = _blogService.TUpdate(updateBlogDto);
            return TPutResponseAction(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var value = await _blogService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
