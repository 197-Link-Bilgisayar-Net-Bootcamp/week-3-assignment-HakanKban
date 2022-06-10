using Microsoft.AspNetCore.Mvc;
using Week3.Data.Dto;
using Week3.Data.Models;
using Week3.Service.Abstract;

namespace Week3.API.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll().ToList();
            return CreateActionResult(CustomResponseDto<List<Category>>.Success(200, categories));
        }
        [HttpPost] 
        public async Task<IActionResult> AddCategory(Category category)
        {
            var addCategory = await _categoryService.AddAsync(category);
            return CreateActionResult(CustomResponseDto<Category>.Success(201,addCategory));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryService.UpdateAsync(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}
