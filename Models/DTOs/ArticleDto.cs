using SolidExample.Models.Entities;

namespace SolidExample.Models.DTOs
{
    public class ArticleDto : BaseEntityDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
