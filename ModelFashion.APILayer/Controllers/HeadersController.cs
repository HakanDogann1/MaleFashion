using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using MaleFashion.DtoLayer.Dtos.HeaderDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadersController : APIControllerExtension
    {
        private readonly IHeaderService _headerService;

        public HeadersController(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _headerService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateHeaderDto createHeaderDto)
        {
            var value = await _headerService.TAddAsync(createHeaderDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateHeaderDto updateHeaderDto)
        {
            var value = _headerService.TUpdate(updateHeaderDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _headerService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _headerService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
