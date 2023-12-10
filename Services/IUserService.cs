using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public interface IUserService
    {
        Task AddOrUpdateAsync(UserBO entry);
        Task<IEnumerable<UserBO>> GetAsync();
        Task<UserBO> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        IEnumerable<UserBO> Where(Expression<Func<User, bool>> exp);
        string SendEmail(string email);
    }
}
