using InventoryUserAPI.Application.DTOs.UsersRoles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Interfaces.IUsersRoles
{
    public interface IUserRepository
    {
        Task<string?> CreateUserAsync(CreateUserRequestDto dto);
        Task<string?> RegisterUserAsync(RegisterUserDto dto);
        Task<UserDetailDto> GetUserByIdAsync(string id);

        Task<bool> UpdateUserAsync(UpdateUserDto dto);
        Task<bool> DeleteUserAsync(string id);

        Task<UserDto?> LoginUserAsync(LoginUserDto dto);

        Task<IEnumerable<UserDto>> GetAllUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<SellerUserDto>> GetAllSellerUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<AdminUserDto>> GetAllAdminUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10);
    }
}
