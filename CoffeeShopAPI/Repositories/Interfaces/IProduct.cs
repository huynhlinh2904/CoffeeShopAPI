using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Repositories.Interfaces
{
    public interface IProduct
    {
        public Task<IEnumerable<ProductResponse>> GetProductsAsync();
    }
}
