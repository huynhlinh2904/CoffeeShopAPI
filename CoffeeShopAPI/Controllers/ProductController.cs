using CoffeeShopAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("API/V1/Product")]
    [ApiController]
    public class ProductController : BaseAPIController
    {
        private readonly IProduct product;
        public ProductController(IProduct ProductService) 
        {
            this.product = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var result = await product.GetAllProductsAsync();
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
