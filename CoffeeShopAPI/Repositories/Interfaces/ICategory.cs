using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Models.Request.CategoryRequest;
using CoffeeShopAPI.Models.Response.ProductResponse;

namespace CoffeeShopAPI.Repositories.Interfaces
{
    public interface ICategory
    {
        public Task<APIResponse<IEnumerable<CreateCategoryResponse>>> GetCategory();
        public Task<APIResponse<CreateCategoryResponse>> CreateCategory(CreateCategoryRequest request);
    }
}
