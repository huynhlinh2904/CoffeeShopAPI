using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Models.ProductResponse;

namespace CoffeeShopAPI.Repositories.Interfaces
{
    public interface IProduct
    {
        public Task<APIResponse<IEnumerable<ProductResponse>>> GetAllProductsAsync();
        public Task<APIResponse<ProductResponse>> CreateProductsAsync();
    }
}
