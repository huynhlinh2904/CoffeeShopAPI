using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models.Request.CategoryRequest;
using CoffeeShopAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("API/V1/Category")]
    [ApiController]
    public class CategoryController : BaseAPIController
    {
        private readonly ICategory category;

        public CategoryController(ICategory category) 
        {
            this.category = category;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync()
        {
            try
            {
                var result = await category.GetCategory();
                if (result == null)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi từ backend.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            try
            {
                var result = await category.CreateCategory(request);
                if (result == null)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi từ backend.");
            }
        }
       
    }
}
