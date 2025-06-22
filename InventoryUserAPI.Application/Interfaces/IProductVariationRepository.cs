using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces
{
    public interface IProductVariationRepository : IRepository<ProductVariation>
    {
        Task<IEnumerable<ProductVariation>> GetAllWithDetailsAsync();
    }
}
