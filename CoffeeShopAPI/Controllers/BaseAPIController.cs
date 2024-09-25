using CoffeeShopAPI.CoreModel;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    public class BaseAPIController : ControllerBase
    {
        protected IActionResult SendResponse<T>(T response) where T : ApiResponse
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        protected IActionResult SendResponse<T>(APIResponse<T> response) where T : class
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        protected IActionResult SendResponse(ApiResponseListError response)
        {
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
