namespace InventoryUserAPI.Application.DTOs.UsersRoles
{
    public class RegisterUserDto
    {

        //siempre seran user por default
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
