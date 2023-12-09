namespace SolidExample.Models.DTOs
{
    public class UserDto : BaseEntityDto
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
