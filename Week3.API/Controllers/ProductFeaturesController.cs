using Microsoft.AspNetCore.Mvc;
using Week3.Data.Dto;
using Week3.Data.Models;
using Week3.Service.Abstract;

namespace Week3.API.Controllers
{
    public class ProductFeaturesController : CustomBaseController
    {
        private readonly IProductFeaturesService _productFeaturesService;

        public ProductFeaturesController(IProductFeaturesService productFeaturesService)
        {
            _productFeaturesService = productFeaturesService;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productFeaturesService.GetAll().ToList();
            return CreateActionResult(CustomResponseDto<List<ProductFeature>>.Success(200, products));
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductFeature product)
        {
            var products = await _productFeaturesService.AddAsync(product);
            return CreateActionResult(CustomResponseDto<ProductFeature>.Success(201, products));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductFeature product)
        {
            await _productFeaturesService.UpdateAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productFeaturesService.GetByIdAsync(id);
            await _productFeaturesService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
