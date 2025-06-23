using System.Collections.Generic;

namespace InventoryUserAPI.Application.DTOs.UsersRoles
{
    public class CreateUserRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
