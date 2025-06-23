using InventoryUserAPI.Domain.Entities;

public class ProductVariationDto
{
    public int Id { get; set; }
    public Product Product { get; set; } = null!; 
    public string ColorName { get; set; }
    public decimal PriceAmount { get; set; }
}
