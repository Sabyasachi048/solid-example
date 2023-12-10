using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IArticleService
    {
        Task AddOrUpdateAsync(ArticleBO entry);
        Task<IEnumerable<ArticleBO>> GetAsync();
        Task<ArticleBO> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        IEnumerable<ArticleBO> Where(Expression<Func<Article, bool>> exp);
    }
}
