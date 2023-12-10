using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IArticleService
    {
        Task AddOrUpdate(ArticleBO entry);
        Task<IEnumerable<ArticleBO>> GetAsync();
        Task<ArticleBO> GetById(Guid id);
        Task Remove(Guid id);
        IEnumerable<ArticleBO> Where(Expression<Func<Article, bool>> exp);
    }
}
