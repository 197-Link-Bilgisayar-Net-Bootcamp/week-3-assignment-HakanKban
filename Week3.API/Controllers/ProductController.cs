using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week3.Data.Context;
using Week3.Data.Dto;
using Week3.Data.Models;
using Week3.Service.Abstract;


namespace Week3.API.Controllers
{
   
    public class ProductController : CustomBaseController
    {
      // Dependecy Injection yapısını kullandık, interfacelerden nesne örneği türetemediğimiz için
      // nesne referansı alarak constructorda kullandık ve arka planda autofac ile oluşturduğumuz yapı ile
      // crud metodlarını barındıran sınıfa erişebildik. 
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
           
            _productService = productService;
        }

        //Generic yapıyı kullanarak metodlarda başarılı mesajlarını döndük
        [HttpGet]
        public  IActionResult GetAllProducts()
        {
            var products = _productService.GetAll().ToList();
            return CreateActionResult(CustomResponseDto<List<Product>>.Success(200,products ));  
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var products = await _productService.AddAsync(product);
            return CreateActionResult(CustomResponseDto<Product>.Success(201, products));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.UpdateAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        // id ' den bularak sildik
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product= await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
