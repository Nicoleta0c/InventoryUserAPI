namespace InventoryUserAPI.Application.DTOs.UsersRoles
{
    public class UpdateUserDto
    {
        public string Id { get; set; }                 
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }         
    }
}
