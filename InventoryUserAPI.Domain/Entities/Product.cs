using System.Text.Json.Serialization;

namespace InventoryUserAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Brand { get; set; } = null!;

        //simplificar respuesta sin crear DTOs

        [JsonIgnore]
        public List<ProductVariation> Variations { get; set; } = new List<ProductVariation>();
    }
}
