using InventoryUserAPI.Application.DTOs.UsersRoles;
using InventoryUserAPI.Application.Interfaces.IUsersRoles;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userService.LoginUserAsync(dto);
        if (user == null)
            return Unauthorized(new { Message = "Credenciales inválidas" });

        return Ok(new { Message = "Login exitoso", User = user });
    }
}
