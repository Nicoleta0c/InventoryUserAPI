using InventoryUserAPI.Application.Interfaces.IProducts;
using InventoryUserAPI.Domain.Entities;
using InventoryUserAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryUserAPI.Infrastructure.Repositories.ProductsRespositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Product> Products, int TotalPages)> GetAllWithColorFilterAsync(string? colorFilter, int pageNumber, int pageSize)
        {
            var query = _context.Products
                .Include(p => p.Variations)
                    .ThenInclude(v => v.Color)
                .AsQueryable();

            if (!string.IsNullOrEmpty(colorFilter))
            {
                query = query.Where(p => p.Variations.Any(v => v.Color != null && v.Color.Name.ToLower() == colorFilter.ToLower()));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var products = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalPages);
        }
    }
}
