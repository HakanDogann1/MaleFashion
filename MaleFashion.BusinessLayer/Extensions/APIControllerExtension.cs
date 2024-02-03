using MaleFashion.SharedLayer;
using MaleFashion.SharedLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Extensions
{

    public class APIControllerExtension : ControllerBase
    {
        [HttpPost]
       public IActionResult TPostResultAction<T>(Response<T> response) where T : class
        {
            if(response.ResponseType==ResponseType.Success)
            {
                return Ok(response.Data);
            }
            else if (response.ResponseType == ResponseType.Fail)
            {
                return BadRequest(response.ErrorDto.Errors.ToList());
            }
            else
            {
                return BadRequest(response.ValidationError);
            }
        }
        [HttpGet]
        public IActionResult TGetResponseAction<T>(Response<T> response) where T: class
        {
            if(response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Data);
            }
         
          return BadRequest(response.ErrorDto.Errors.ToList());
          
        }
       
        [HttpPut]
        public IActionResult TPutResponseAction<T>(Response<T> response) where T : class
        {
            if (response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Data);
            }
            else if (response.ResponseType == ResponseType.Fail)
            {
                return BadRequest(response.ErrorDto.Errors);
            }
            else
            {
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult TDeleteResponseAction<T>(Response<T> response) 
        {
            if(response.ResponseType == ResponseType.Success)
            {
                return Ok("Silme işlemi başarılı");
            }
            return BadRequest("Silme işlemi başarısız.");
        }

    }
}
