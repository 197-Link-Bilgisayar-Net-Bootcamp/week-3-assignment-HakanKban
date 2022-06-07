using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week3.Service.Abstract;

namespace Week3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAll());
        }
    }
}
