using AutoMapper;
using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models.Request.CategoryRequest;
using CoffeeShopAPI.Models.Response.ProductResponse;
using CoffeeShopAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopAPI.Repositories.Services
{
    public class CategoryService : ICategory
    {
        private readonly MilkTea2024Context db;
        private readonly IMapper mapper;
        public CategoryService(MilkTea2024Context db, IMapper mapper) 
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<APIResponse<CreateCategoryResponse>> CreateCategory(CreateCategoryRequest request)
        {
            APIResponse<CreateCategoryResponse> response = new();
            var id = Guid.NewGuid();
            Category result = new Category()
            {
                CategoryId = id,
                CategoryName = request.CategoryName,
                Status = true,
            };

            if(result.CategoryId == request.CategoryId)
            {
                response.ToFailedResponse("id trùng lặp không khởi tạo", StatusCodes.Status400BadRequest);
                return response;
            }
            await db.Categories.AddAsync(result);
            await db.SaveChangesAsync();
            var map = mapper.Map<CreateCategoryResponse>(result);
            response.ToSuccessResponse(response.Data = map, "tạo thành công", StatusCodes.Status200OK);
            return response;

        }

        public async Task<APIResponse<IEnumerable<CreateCategoryResponse>>> GetCategory()
        {
            APIResponse<IEnumerable<CreateCategoryResponse>> response = new();
            var category = await db.Categories.ToListAsync();
            if (category == null) 
            {
                response.ToFailedResponse("không tồn tại loại nào", StatusCodes.Status404NotFound);
                return response;
            }
            List<CreateCategoryResponse> result = new();
            foreach (var item in category) 
            {
                var categoryResponse = new CreateCategoryResponse();
                {
                    categoryResponse.CategoryId = item.CategoryId;
                    categoryResponse.CategoryName = item.CategoryName ?? "";
                    categoryResponse.Status = item.Status;
                }
                result.Add(categoryResponse);
            }
            if (result == null) 
            {
                response.ToFailedResponse("không tồn tại category", StatusCodes.Status404NotFound);
                return response;
            }
            response.ToSuccessResponse(response.Data = result, "lấy danh sách thành công", StatusCodes.Status200OK);
            return response;
        }

        
    }
}
