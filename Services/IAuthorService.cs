using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IAuthorService
    {
        Task AddOrUpdate(AuthorBO entry);
        Task<IEnumerable<AuthorBO>> GetAsync();
        Task<AuthorBO> GetById(Guid id);
        Task Remove(Guid id);
        IEnumerable<AuthorBO> Where(Expression<Func<Author, bool>> exp);
    }
}
