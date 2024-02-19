using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Extensions;
using MaleFashion.DtoLayer.Dtos.CouponCodeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelFashion.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponCodesController : APIControllerExtension
    {
        private readonly ICouponCodeService _couponCodeService;

        public CouponCodesController(ICouponCodeService couponCodeService)
        {
            _couponCodeService = couponCodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = await _couponCodeService.TGetAllAsync();
            return TGetResponseAction(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _couponCodeService.TGetByIdAsync(id);
            return TGetResponseAction(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCouponCodeDto couponCodeDto)
        {
            var value = await _couponCodeService.TAddAsync(couponCodeDto);
            return TPostResultAction(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateCouponCodeDto couponCodeDto)
        {
            var value = _couponCodeService.TUpdate(couponCodeDto);
            return TPutResponseAction(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _couponCodeService.TDelete(id);
            return TDeleteResponseAction(value);
        }
    }
}
