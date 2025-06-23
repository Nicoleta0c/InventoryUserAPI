using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Application.Interfaces.IProducts;
using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Services.ProductsService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductVariationRepository _variationRepository;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IProductVariationRepository variationRepository)
        {
            _productRepository = productRepository;
            _variationRepository = variationRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<(IEnumerable<Product>, int totalPages)> GetAllAsync(string? colorFilter, int pageNumber, int pageSize)
        {
            return await _productRepository.GetAllWithColorFilterAsync(colorFilter, pageNumber, pageSize);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return product;
        }

        public async Task<IEnumerable<ProductVariationDto>> GetAllDtoAsync()
        {
            var variations = await _variationRepository.GetAllWithDetailsAsync();

            return variations.Select(v => new ProductVariationDto
            {
                Id = v.Id,
                Product = v.Product!,
                ColorName = v.Color?.Name ?? string.Empty,
                PriceAmount = v.Price?.Amount ?? 0
            });
        }


        public async Task<Product> CreateAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return product;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _productRepository.Update(product);
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
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _productRepository.Delete(entity);
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
    }


}
