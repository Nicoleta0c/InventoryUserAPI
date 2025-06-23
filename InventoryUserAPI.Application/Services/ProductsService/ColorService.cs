using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Application.Interfaces.IProducts;
using InventoryUserAPI.Application.Utils;
using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Services.ProductsService
{
    public class ColorService : IColorService
    {
        private readonly IRepository<Color> _colorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ColorService(IRepository<Color> colorRepository, IUnitOfWork unitOfWork)
        {
            _colorRepository = colorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            return await _colorRepository.GetByIdAsync(id);
        }


        public async Task<(IEnumerable<Color> Colors, int TotalPages)> GetAllAsync(int pageNumber, int pageSize)
        {
            var colors = await _colorRepository.GetAllAsync();

            int totalItems = colors.Count();

            var pagedColors = PaginationHelper.Paginate(colors.AsQueryable(), pageNumber, pageSize);

            int totalPages = PaginationHelper.GetTotalPages(totalItems, pageSize);

            return (pagedColors.ToList(), totalPages);
        }
    }
}
