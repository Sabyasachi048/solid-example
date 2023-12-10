using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IAuthorService
    {
        Task AddOrUpdateAsync(AuthorBO entry);
        Task<IEnumerable<AuthorBO>> GetAsync();
        Task<AuthorBO> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        IEnumerable<AuthorBO> Where(Expression<Func<Author, bool>> exp);
    }
}
