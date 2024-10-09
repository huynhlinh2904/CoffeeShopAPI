using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Models.Request.ProductRequest;
using CoffeeShopAPI.Models.Response.ProductResponse;

namespace CoffeeShopAPI.Repositories.Interfaces
{
    public interface IProduct
    {
        public Task<APIResponse<IEnumerable<GetResponse>>> GetAllProductsAsync();
        public Task<APIResponse<CreateResponse>> CreateProductsAsync(CreateRequest req);
    }
}
