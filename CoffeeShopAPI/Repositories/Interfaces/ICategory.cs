using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Models.Response.ProductResponse;

namespace CoffeeShopAPI.Repositories.Interfaces
{
    public interface ICategory
    {
        public Task<APIResponse<IEnumerable<CreateCategoryResponse>>> GetCategory();
    }
}
