using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces.IProducts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<(IEnumerable<Product> Products, int TotalPages)> GetAllWithColorFilterAsync(string? colorFilter, int pageNumber, int pageSize);
    }
}
