namespace SolidExample.Models.BOs
{
    public class BaseEntityBO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
