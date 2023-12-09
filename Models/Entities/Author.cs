namespace SolidExample.Models.Entities
{
    public class Author : User
    {
        public string Description { get; set; }

        public IEnumerable<Article> Articles { get; set; }
    }
}
