using InventoryUserAPI.Application.DTOs.UsersRoles;
using InventoryUserAPI.Application.Interfaces.IUsersRoles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.Application.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<string?> CreateUserAsync(CreateUserRequestDto dto)
            => _userRepository.CreateUserAsync(dto);

        public Task<string?> RegisterUserAsync(RegisterUserDto dto)
            => _userRepository.RegisterUserAsync(dto);

        public Task<UserDto?> LoginUserAsync(LoginUserDto dto)
            => _userRepository.LoginUserAsync(dto);

        public Task<IEnumerable<UserDto>> GetAllUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10)
            => _userRepository.GetAllUsersAsync(filter, pageNumber, pageSize);

        public Task<IEnumerable<SellerUserDto>> GetAllSellerUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10)
            => _userRepository.GetAllSellerUsersAsync(filter, pageNumber, pageSize);

        public Task<IEnumerable<AdminUserDto>> GetAllAdminUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10)
            => _userRepository.GetAllAdminUsersAsync(filter, pageNumber, pageSize);

        public Task<UserDetailDto> GetUserByIdAsync(string id)
            => _userRepository.GetUserByIdAsync(id);

        public Task<bool> UpdateUserAsync(UpdateUserDto dto)
            => _userRepository.UpdateUserAsync(dto);

        public Task<bool> DeleteUserAsync(string id)
            => _userRepository.DeleteUserAsync(id);
    }
}
