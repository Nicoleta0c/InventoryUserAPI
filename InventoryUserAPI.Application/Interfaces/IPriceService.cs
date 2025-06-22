using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces
{
    public interface IPriceService
    {
        Task<IEnumerable<Price>> GetAllAsync();
        Task<Price?> GetByIdAsync(int id);
        Task<Price> CreateAsync(Price price);
        Task<bool> UpdateAsync(Price price);
        Task<bool> DeleteAsync(int id);
    }
}
