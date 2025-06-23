using InventoryUserAPI.Application.Interfaces.IProducts;
using InventoryUserAPI.Domain.Entities;
using InventoryUserAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Infrastructure.Repositories.ProductsRespositories
{
    public class ProductVariationRepository : Repository<ProductVariation>, IProductVariationRepository
    {
        private new readonly AppDbContext _context;

        public ProductVariationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVariation>> GetAllWithDetailsAsync()
        {
            return await _context.ProductVariations
                .Include(pv => pv.Product)
                .Include(pv => pv.Color)
                .Include(pv => pv.Price)
                .ToListAsync();
        }
    }
}
