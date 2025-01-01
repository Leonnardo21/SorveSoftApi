namespace SorveSoftApi.Models
{
    public class Menu
    {
        public List<Combo> Combos { get; set; } = new List<Combo>();
    }
    public class Combo
    {
        public string Name { get; set; } = string.Empty;
        public List<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
        public decimal? PromotionalPrice { get; set; }
    }

    public class ProductDetail
    {
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
