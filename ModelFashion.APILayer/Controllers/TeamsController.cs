using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.TeamDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : APIControllerExtension
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _teamService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateTeamDto createTeamDto)
        {
            var value = await _teamService.TAddAsync(createTeamDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateTeamDto updateTeamDto)
        {
            var value = _teamService.TUpdate(updateTeamDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _teamService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _teamService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
