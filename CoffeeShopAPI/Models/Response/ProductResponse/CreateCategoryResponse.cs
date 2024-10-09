namespace CoffeeShopAPI.Models.Response.ProductResponse
{
    public class CreateCategoryResponse
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool? Status { get; set; }
    }
}
