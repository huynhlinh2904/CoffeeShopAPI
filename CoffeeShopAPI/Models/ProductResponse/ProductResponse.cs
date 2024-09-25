namespace CoffeeShopAPI.Models.ProductResponse
{
    public class ProductResponse
    {
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public bool? BestSeller { get; set; }
        public bool? Status { get; set; }
    }
}
