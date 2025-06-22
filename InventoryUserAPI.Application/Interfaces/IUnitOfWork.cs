using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
