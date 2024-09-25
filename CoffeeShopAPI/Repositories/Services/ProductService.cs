using AutoMapper;
using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models.ProductResponse;
using CoffeeShopAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopAPI.Repositories.Services
{
    public class ProductService : IProduct
    {
        private readonly MilkTea2024Context db;
        private readonly IMapper mapper;

        public ProductService(MilkTea2024Context db, IMapper mapper ) {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<APIResponse<IEnumerable<ProductResponse>>> GetAllProductsAsync()
        {
            APIResponse<IEnumerable<ProductResponse>> response = new();
            var product = await db.Products.Where(p => p.Status == true).ToListAsync();
            if (product == null)
            {
                response.ToFailedResponse("sản phẩm không tồn tại", StatusCodes.Status404NotFound);
                return response;
            }
            IEnumerable<ProductResponse> result = product.Select(
                p =>
                {
                    return new ProductResponse()
                    {
                        ProductName = p.ProductName ?? "",
                        Price = p.Price,
                        Status = p.Status,
                        BestSeller = p.BestSeller,
                    };
                }).ToList();
            var map = mapper.Map<IEnumerable<ProductResponse>>(result);
            response.ToSuccessResponse("lấy danh sách thành công", StatusCodes.Status200OK);
            response.Data = map;
            return response;
        }
    }
}
