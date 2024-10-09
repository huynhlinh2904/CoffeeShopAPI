using AutoMapper;
using CoffeeShopAPI.CoreModel;
using CoffeeShopAPI.Data;
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

        public async Task<APIResponse<IEnumerable<CreateCategoryResponse>>> GetCategory()
        {
            APIResponse<IEnumerable<CreateCategoryResponse>> response = new();
            var category = await db.Categories.ToListAsync();
            if (category == null) 
            {
                response.ToFailedResponse("không tồn tại loại nào", StatusCodes.Status404NotFound);
                return response;
            }
            List<CreateCategoryResponse> categories = new List<CreateCategoryResponse>();
            foreach (var item in category) 
            {
                var categoryResponse = new CreateCategoryResponse();
                {
                    categoryResponse.CategoryId = item.CategoryId;
                    categoryResponse.CategoryName = item.CategoryName ?? "";
                    categoryResponse.Status = item.Status;
                }
                categories.Add(categoryResponse);
            }
            if (categories == null) 
            {
                response.ToFailedResponse("không tồn tại category", StatusCodes.Status404NotFound);
                return response;
            }
            response.ToSuccessResponse(response.Data = categories, "lấy danh sách thành công", StatusCodes.Status200OK);
            return response;
        }
    }
}
