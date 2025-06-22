using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces
{
    public interface IProductService
    {
        Task<(IEnumerable<Product>, int totalPages)> GetAllAsync(string? colorFilter, int pageNumber, int pageSize);
        Task<Product> AddAsync(Product product);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
