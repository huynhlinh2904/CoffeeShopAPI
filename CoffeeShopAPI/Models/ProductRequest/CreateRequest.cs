namespace CoffeeShopAPI.Models.ProductRequest
{
    public class CreateRequest
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int? PriceOfSizeM { get; set; }
        public int? PriceOfSizeL { get; set; }
        public bool? BestSeller { get; set; }
        public bool? Status { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
