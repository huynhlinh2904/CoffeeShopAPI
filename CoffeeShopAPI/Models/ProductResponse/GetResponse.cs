namespace CoffeeShopAPI.Models.ProductResponse
{
    public class GetResponse
    {
        public string ProductName { get; set; } = string.Empty;
        public int? Price { get; set; }
        public bool? BestSeller { get; set; }
        public bool? Status { get; set; }

        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
