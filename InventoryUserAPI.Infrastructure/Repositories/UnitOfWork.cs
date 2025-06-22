using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Infrastructure.Data;
using System.Threading.Tasks;

namespace InventoryUserAPI.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
