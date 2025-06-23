using InventoryUserAPI.Application.DTOs.UsersRoles;
using InventoryUserAPI.Application.Interfaces.IUsersRoles;
using InventoryUserAPI.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryUserAPI.Infrastructure.Repositories.UsersRespositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<UserRepository> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private async Task<string?> CreateBaseUserAsync(string userName, string email, string password, IEnumerable<string>? roles = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    _logger.LogWarning("Datos de entrada inválidos para crear usuario: UserName={UserName}, Email={Email}", userName, email);
                    return null;
                }

                var userExists = await _userManager.FindByNameAsync(userName);
                if (userExists != null)
                {
                    _logger.LogWarning("El usuario {UserName} ya existe", userName);
                    return null;
                }

                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = email
                };

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    _logger.LogError("Error al crear usuario {UserName}: {Errors}", userName, string.Join(", ", result.Errors.Select(e => e.Description)));
                    return null;
                }

                var rolesToAssign = roles ?? new List<string>();
                foreach (var role in rolesToAssign)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        var roleResult = await _userManager.AddToRoleAsync(user, role);
                        if (!roleResult.Succeeded)
                        {
                            _logger.LogError("Error al asignar rol {Role} al usuario {UserName}: {Errors}", role, userName, string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                            return null;
                        }
                    }
                }

                _logger.LogInformation("Usuario {UserName} creado exitosamente", userName);
                return user.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al crear usuario {UserName}", userName);
                return null;
            }
        }

        public async Task<string?> CreateUserAsync(CreateUserRequestDto dto)
        {
            if (dto == null)
            {
                _logger.LogWarning("CreateUserRequestDto es nulo");
                return null;
            }

            return await CreateBaseUserAsync(dto.UserName, dto.Email, dto.Password, dto.Roles);
        }

        public async Task<string?> RegisterUserAsync(RegisterUserDto dto)
        {
            if (dto == null)
            {
                _logger.LogWarning("RegisterUserDto es nulo");
                return null;
            }

            return await CreateBaseUserAsync(dto.UserName, dto.Email, dto.Password, new[] { "User" });
        }

        public async Task<UserDto?> LoginUserAsync(LoginUserDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password) || string.IsNullOrWhiteSpace(dto.Role))
            {
                _logger.LogWarning("Datos inválidos para login");
                return null;
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                _logger.LogWarning("Usuario con email {Email} no encontrado", dto.Email);
                return null;
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: false);
            if (!signInResult.Succeeded)
            {
                _logger.LogWarning("Contraseña incorrecta para usuario {Email}", dto.Email);
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains(dto.Role))
            {
                _logger.LogWarning("Usuario {Email} no tiene rol requerido {Role}", dto.Email, dto.Role);
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = roles.ToList()
            };
        }

        private async Task<IEnumerable<T>> GetFilteredUsersAsync<T>(
            string? filter = null,
            int pageNumber = 1,
            int pageSize = 10,
            Func<ApplicationUser, IList<string>, T> mapper = null,
            Func<IList<string>, bool>? roleFilter = null)
            where T : class
        {
            try
            {
                var usersQuery = _userManager.Users.AsQueryable();

                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.ToLower();
                    usersQuery = usersQuery.Where(u =>
                        u.UserName.ToLower().Contains(filter) ||
                        u.Email.ToLower().Contains(filter));
                }

                usersQuery = usersQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

                var users = await usersQuery.ToListAsync();
                var results = new List<T>();

                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roleFilter == null || roleFilter(roles))
                    {
                        results.Add(mapper(user, roles));
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al obtener usuarios con filtro {Filter}", filter);
                return new List<T>();
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10)
        {
            return await GetFilteredUsersAsync(
                filter,
                pageNumber,
                pageSize,
                (user, roles) => new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList()
                });
        }

        public async Task<IEnumerable<SellerUserDto>> GetAllSellerUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10)
        {
            return await GetFilteredUsersAsync(
                filter,
                pageNumber,
                pageSize,
                (user, roles) => new SellerUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                },
                roles => roles.Contains("Seller"));
        }

        public async Task<IEnumerable<AdminUserDto>> GetAllAdminUsersAsync(string? filter = null, int pageNumber = 1, int pageSize = 10)
        {
            return await GetFilteredUsersAsync(
                filter,
                pageNumber,
                pageSize,
                (user, roles) => new AdminUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList()
                },
                roles => roles.Contains("Admin"));
        }

        public async Task<UserDetailDto> GetUserByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    _logger.LogWarning("ID de usuario inválido");
                    return null;
                }

                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    _logger.LogWarning("Usuario con ID {Id} no encontrado", id);
                    return null;
                }

                var roles = await _userManager.GetRolesAsync(user);

                return new UserDetailDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al obtener usuario con ID {Id}", id);
                return null;
            }
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            try
            {
                if (dto == null || string.IsNullOrWhiteSpace(dto.Id) || string.IsNullOrWhiteSpace(dto.UserName) || string.IsNullOrWhiteSpace(dto.Email))
                {
                    _logger.LogWarning("Datos de entrada inválidos para actualizar usuario: ID={Id}, UserName={UserName}, Email={Email}", dto?.Id, dto?.UserName, dto?.Email);
                    return false;
                }

                var user = await _userManager.FindByIdAsync(dto.Id);
                if (user == null)
                {
                    _logger.LogWarning("Usuario con ID {Id} no encontrado", dto.Id);
                    return false;
                }

                var userWithSameName = await _userManager.FindByNameAsync(dto.UserName);
                if (userWithSameName != null && userWithSameName.Id != dto.Id)
                {
                    _logger.LogWarning("El UserName {UserName} ya está en uso por otro usuario", dto.UserName);
                    return false;
                }

                var userWithSameEmail = await _userManager.FindByEmailAsync(dto.Email);
                if (userWithSameEmail != null && userWithSameEmail.Id != dto.Id)
                {
                    _logger.LogWarning("El Email {Email} ya está en uso por otro usuario", dto.Email);
                    return false;
                }

                user.UserName = dto.UserName;
                user.Email = dto.Email;

                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    _logger.LogError("Error al actualizar usuario {UserName}: {Errors}", dto.UserName, string.Join(", ", updateResult.Errors.Select(e => e.Description)));
                    return false;
                }

                var currentRoles = await _userManager.GetRolesAsync(user);
                var rolesToAssign = dto.Roles ?? new List<string>();

                var rolesToRemove = currentRoles.Except(rolesToAssign).ToList();
                if (rolesToRemove.Any())
                {
                    var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    if (!removeResult.Succeeded)
                    {
                        _logger.LogError("Error al eliminar roles del usuario {UserName}: {Errors}", dto.UserName, string.Join(", ", removeResult.Errors.Select(e => e.Description)));
                        return false;
                    }
                }

                var rolesToAdd = rolesToAssign.Except(currentRoles).ToList();
                foreach (var role in rolesToAdd)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        var addResult = await _userManager.AddToRoleAsync(user, role);
                        if (!addResult.Succeeded)
                        {
                            _logger.LogError("Error al agregar rol {Role} al usuario {UserName}: {Errors}", role, dto.UserName, string.Join(", ", addResult.Errors.Select(e => e.Description)));
                            return false;
                        }
                    }
                }

                _logger.LogInformation("Usuario {UserName} actualizado exitosamente", dto.UserName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al actualizar usuario con ID {Id}", dto?.Id);
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    _logger.LogWarning("ID de usuario inválido para eliminación");
                    return false;
                }

                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    _logger.LogWarning("Usuario con ID {Id} no encontrado", id);
                    return false;
                }

                var deleteResult = await _userManager.DeleteAsync(user);
                if (!deleteResult.Succeeded)
                {
                    _logger.LogError("Error al eliminar usuario con ID {Id}: {Errors}", id, string.Join(", ", deleteResult.Errors.Select(e => e.Description)));
                    return false;
                }

                _logger.LogInformation("Usuario con ID {Id} eliminado exitosamente", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al eliminar usuario con ID {Id}", id);
                return false;
            }
        }
    }
}
