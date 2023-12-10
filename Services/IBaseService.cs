using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IBaseService<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();

        Task<T> GetByIdAsync(Guid id);

        IEnumerable<T> Where(Expression<Func<T, bool>> exp);

        Task AddOrUpdateAsync(T entry);

        Task RemoveAsync(Guid id);
    }
}
