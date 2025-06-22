using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProductVariationService : IProductVariationService
{
    private readonly IProductVariationRepository _variationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductVariationService(IProductVariationRepository variationRepository, IUnitOfWork unitOfWork)
    {
        _variationRepository = variationRepository;
        _unitOfWork = unitOfWork;
    }

    private ProductVariationDto ToDto(ProductVariation v) => new ProductVariationDto
    {
        Id = v.Id,
        ProductName = v.Product?.Name ?? "",
        ColorName = v.Color?.Name ?? "",
        PriceAmount = v.Price?.Amount ?? 0m
    };

    public async Task<IEnumerable<ProductVariationDto>> GetAllWithDetailsAsync()
    {
        var variations = await _variationRepository.GetAllWithDetailsAsync();
        return variations.Select(ToDto).ToList();
    }

    public async Task<IEnumerable<ProductVariationDto>> GetByColorNameAsync(string colorName)
    {
        var all = await _variationRepository.GetAllWithDetailsAsync();
        var filtered = all.Where(v => v.Color != null && v.Color.Name.ToLower() == colorName.ToLower());
        return filtered.Select(ToDto).ToList();
    }

    public async Task<IEnumerable<ProductVariationDto>> GetAllAsync()
    {
        var all = await _variationRepository.GetAllWithDetailsAsync();
        return all.Select(ToDto).ToList();
    }

    public async Task<ProductVariationDto?> GetByIdAsync(int id)
    {
        var entity = await _variationRepository.GetByIdAsync(id);
        if (entity == null) return null;
        return ToDto(entity);
    }

    public async Task<IEnumerable<ProductVariationDto>> GetByColorAsync(int colorId)
    {
        var all = await _variationRepository.GetAllWithDetailsAsync();
        var filtered = all.Where(v => v.ColorId == colorId);
        return filtered.Select(ToDto).ToList();
    }

    public async Task<(IEnumerable<string> VariationsDisplay, int TotalPages)> GetDisplayByColorAsync(int? colorId, int pageNumber, int pageSize)
    {
        var allVariations = await _variationRepository.GetAllWithDetailsAsync();

        if (colorId.HasValue)
        {
            allVariations = allVariations.Where(v => v.ColorId == colorId.Value);
        }

        int totalItems = allVariations.Count();
        int totalPages = (int)System.Math.Ceiling(totalItems / (double)pageSize);

        var pagedVariations = allVariations
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        var displayList = pagedVariations
            .Select(v => $"{v.Product.Name} {v.Color.Name} {v.Price.Amount}")
            .ToList();

        return (displayList, totalPages);
    }

    public async Task<ProductVariationDto> CreateAsync(ProductVariation variation)
    {
        await _variationRepository.AddAsync(variation);
        await _unitOfWork.SaveAsync();
        return ToDto(variation);
    }

    public async Task<bool> UpdateAsync(ProductVariation variation)
    {
        _variationRepository.Update(variation);
        try
        {
            await _unitOfWork.SaveAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _variationRepository.GetByIdAsync(id);
        if (entity == null) return false;

        _variationRepository.Delete(entity);
        try
        {
            await _unitOfWork.SaveAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<ProductVariationDto>> GetAllDtoAsync()
    {
        var variations = await _variationRepository.GetAllWithDetailsAsync();

        return variations.Select(ToDto).ToList();
    }
}
