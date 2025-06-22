namespace InventoryUserAPI.Domain.Entities
{
    public class ProductVariation
    {
        public int Id { get; set; }

       
        public int ProductId { get; set; }
        public Product Product { get; set; }

       
        public int ColorId { get; set; }
        public Color Color { get; set; }

       
        public int PriceId { get; set; }
        public Price Price { get; set; }
    }
}
