using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Models.ProductRequest;
using CoffeeShopAPI.Models.ProductResponse;

namespace CoffeeShopAPI.Repositories.Interfaces
{
    public interface IProduct
    {
        public Task<APIResponse<IEnumerable<GetResponse>>> GetAllProductsAsync();
        public Task<APIResponse<CreateResponse>> CreateProductsAsync(CreateRequest req);
    }
}
