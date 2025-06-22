using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces
{
    public interface IColorService
    {
        Task<(IEnumerable<Color> Colors, int TotalPages)> GetAllAsync(int pageNumber, int pageSize);
        Task<Color> GetByIdAsync(int id);

    }
}
