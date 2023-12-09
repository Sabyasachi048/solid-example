namespace SolidExample.Models.Entities
{
    public class User : BaseEntity
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
