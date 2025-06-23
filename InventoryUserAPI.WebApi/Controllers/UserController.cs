using InventoryUserAPI.Application.DTOs.UsersRoles;
using InventoryUserAPI.Application.Interfaces.IUsersRoles;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create/admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateUserRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.Roles = new List<string> { "Admin" };

            var userId = await _userService.CreateUserAsync(dto);
            if (string.IsNullOrEmpty(userId))
                return BadRequest("No se pudo crear usuario o ya existe");

            return Ok(new { Message = "Admin creado", UserId = userId });
        }

        [HttpPost("create/seller")]
        public async Task<IActionResult> CreateSeller([FromBody] CreateUserRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.Roles = new List<string> { "Seller" };

            var userId = await _userService.CreateUserAsync(dto);
            if (string.IsNullOrEmpty(userId))
                return BadRequest("No se pudo crear usuario o ya existe");

            return Ok(new { Message = "Seller creado", UserId = userId });
        }


        [HttpPost("create/user")]
        public async Task<IActionResult> CreateUserRoleUser([FromBody] CreateUserRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.Roles = new List<string> { "User" };

            var userId = await _userService.CreateUserAsync(dto);
            if (string.IsNullOrEmpty(userId))
                return BadRequest("No se pudo crear usuario o ya existe");

            return Ok(new { Message = "User creado", UserId = userId });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = await _userService.RegisterUserAsync(dto);
            if (string.IsNullOrEmpty(userId))
                return BadRequest("No se pudo registrar usuario o ya existe.");

            return Ok(new { Message = "Usuario registrado", UserId = userId });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers([FromQuery] string? filter = null)
        {
            var users = await _userService.GetAllUsersAsync(filter);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("Usuario no encontrado");

            return Ok(user);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
        {
            var result = await _userService.UpdateUserAsync(dto);
            if (!result)
                return BadRequest("No se pudo actualizar el usuario");

            return Ok("Usuario actualizado");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return BadRequest("No se pudo eliminar el usuario");

            return Ok("Usuario eliminado");
        }

        [HttpGet("admins")]
        public async Task<IActionResult> GetAllAdmins([FromQuery] string? filter = null)
        {
            var admins = await _userService.GetAllAdminUsersAsync(filter);
            return Ok(admins);
        }

        [HttpGet("sellers")]
        public async Task<IActionResult> GetAllSellers([FromQuery] string? filter = null)
        {
            var sellers = await _userService.GetAllSellerUsersAsync(filter);
            return Ok(sellers);
        }
    }
}
