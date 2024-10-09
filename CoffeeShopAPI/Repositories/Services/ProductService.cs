using AutoMapper;
using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models.ProductRequest;
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

        public async Task<APIResponse<CreateResponse>> CreateProductsAsync(CreateRequest req)
        {
            APIResponse<CreateResponse> response = new();
            var checkProductId = await db.Products.Where(p => p.ProductId == req.ProductId).SingleOrDefaultAsync();
            if (checkProductId != null)
            {
                response.ToFailedResponse("trùng mã sản phẩm", StatusCodes.Status400BadRequest);
                return response;
            }
            var category = await db.Categories.FirstOrDefaultAsync(c => c.CategoryName == req.CategoryName);
            if (category == null)
            {
                response.ToFailedResponse("Danh mục không tồn tại", StatusCodes.Status400BadRequest);
                return response;
            }
            var id = Guid.NewGuid();
            Product product = new Product()
            {
                ProductId = id,
                ProductName = req.ProductName,
                PriceOfSizeM = req.PriceOfSizeM,
                PriceOfSizeL = req.PriceOfSizeL,
                BestSeller = req.BestSeller,
                Status = true,
                Category = category,
            };
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();

            CreateResponse createResponse = new CreateResponse()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                PriceOfSizeM = product.PriceOfSizeM,
                PriceOfSizeL = product.PriceOfSizeL,
                BestSeller = product.BestSeller,
                Status = product.Status,
                CategoryName = category.CategoryName ?? "",
            };

            var map = mapper.Map<CreateResponse>(createResponse);
            response.ToSuccessResponse("tạo sản phảm thành công", StatusCodes.Status200OK);
            response.Data = map;
            return response;
        }

        public async Task<APIResponse<IEnumerable<GetResponse>>> GetAllProductsAsync()
        {
            APIResponse<IEnumerable<GetResponse>> response = new();
            var products = await db.Products.Where(p => p.Status == true)
            .Join(db.Categories,
            p => p.CategoryId, // Outer key selector (Product.CategoryId)
            c => c.CategoryId, // Inner key selector (Category.CategoryId)
            (p, c) => new { Product = p, Category = c }) // Result selector
            .Select(pc => new GetResponse
            {
                ProductName = pc.Product.ProductName ?? "",
                PriceOfSizeM = pc.Product.PriceOfSizeM,
                PriceOfSizeL = pc.Product.PriceOfSizeL,
                Status = pc.Product.Status,
                BestSeller = pc.Product.BestSeller,
                CategoryId = pc.Product.CategoryId,
                CategoryName = pc.Category.CategoryName ?? ""
            }).ToListAsync();

            if (products == null)
            {
                response.ToFailedResponse("sản phẩm không tồn tại", StatusCodes.Status404NotFound);
                return response;
            }
            var map = mapper.Map<IEnumerable<GetResponse>>(products);
            response.ToSuccessResponse("lấy danh sách thành công", StatusCodes.Status200OK);
            response.Data = map;
            return response;
        }
    }
}
