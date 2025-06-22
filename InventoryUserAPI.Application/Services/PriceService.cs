using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Services
{
    public class PriceService : IPriceService
    {
        private readonly IRepository<Price> _priceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PriceService(IRepository<Price> priceRepository, IUnitOfWork unitOfWork)
        {
            _priceRepository = priceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Price>> GetAllAsync()
        {
            return await _priceRepository.GetAllAsync();
        }

        public async Task<Price?> GetByIdAsync(int id)
        {
            return await _priceRepository.GetByIdAsync(id);
        }


        public async Task<Price> CreateAsync(Price price)
        {
            await _priceRepository.AddAsync(price);
            await _unitOfWork.SaveAsync();
            return price;
        }

        public async Task<bool> UpdateAsync(Price price)
        {
            _priceRepository.Update(price);
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
            var entity = await _priceRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _priceRepository.Delete(entity);
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
