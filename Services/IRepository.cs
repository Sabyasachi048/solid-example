using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid guid);
        IEnumerable<T> Where(Expression<Func<T, bool>> exp);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
