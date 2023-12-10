using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IUserService
    {
        Task AddOrUpdate(UserBO entry);
        Task<IEnumerable<UserBO>> GetAsync();
        Task<UserBO> GetById(Guid id);
        Task Remove(Guid id);
        IEnumerable<UserBO> Where(Expression<Func<User, bool>> exp);
    }
}
