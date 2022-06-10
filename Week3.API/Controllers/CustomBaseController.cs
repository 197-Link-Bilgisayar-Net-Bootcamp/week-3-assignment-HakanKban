using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week3.Data.Dto;

namespace Week3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        //Custom bir controller yazarak response mesajlarını daha efektif kullanımda döndük 
        // NonAction Attribute ile generic yapı olarak kullandığımız metodu yansıtmayacağımız için hata almayı önledik.

        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };



        }
    }
}
