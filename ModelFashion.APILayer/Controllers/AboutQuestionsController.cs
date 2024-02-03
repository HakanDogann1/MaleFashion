using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutQuestionsController : APIControllerExtension
    {
        private readonly IAboutQuestionService _aboutQuestionService;

        public AboutQuestionsController(IAboutQuestionService aboutQuestionService)
        {
            _aboutQuestionService = aboutQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _aboutQuestionService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateAboutQuestionDto createAboutQuestionDto)
        {
            var value = await _aboutQuestionService.TAddAsync(createAboutQuestionDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateAboutQuestionDto updateAboutQuestionDto)
        {
            var value = _aboutQuestionService.TUpdate(updateAboutQuestionDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _aboutQuestionService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _aboutQuestionService.TDelete(id);
            return TDeleteResponseAction(value);
        }
       
    }
}
