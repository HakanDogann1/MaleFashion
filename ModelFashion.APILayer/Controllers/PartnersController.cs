using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.PartnerDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : APIControllerExtension
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _partnerService.TGetAllAsync();
            return TGetResponseAction(values);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreatePartnerDto createPartnerDto)
        {
            var value = await _partnerService.TAddAsync(createPartnerDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdatePartnerDto updatePartnerDto)
        {
            var value = _partnerService.TUpdate(updatePartnerDto);
            return TPutResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _partnerService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _partnerService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
