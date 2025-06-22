using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces
{
    public interface IProductVariationService
    {
        Task<(IEnumerable<string> VariationsDisplay, int TotalPages)> GetDisplayByColorAsync(int? colorId, int pageNumber, int pageSize);

        Task<IEnumerable<ProductVariationDto>> GetAllWithDetailsAsync();

        Task<IEnumerable<ProductVariationDto>> GetByColorNameAsync(string colorName);

        Task<IEnumerable<ProductVariationDto>> GetAllAsync();

        Task<ProductVariationDto?> GetByIdAsync(int id);

        Task<IEnumerable<ProductVariationDto>> GetByColorAsync(int colorId);

        Task<ProductVariationDto> CreateAsync(ProductVariation variation);

        Task<bool> UpdateAsync(ProductVariation variation);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ProductVariationDto>> GetAllDtoAsync();
    }
}
