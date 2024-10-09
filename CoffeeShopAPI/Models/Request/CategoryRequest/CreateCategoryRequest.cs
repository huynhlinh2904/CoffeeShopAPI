namespace CoffeeShopAPI.Models.Request.CategoryRequest
{
    public class CreateCategoryRequest
    {
        public Guid? CategoryId {  get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool? Status { get; set; }
    }
}
