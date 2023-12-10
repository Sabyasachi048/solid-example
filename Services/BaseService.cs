using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _repository.Where(exp);
        }

        public async Task AddOrUpdateAsync(T entry)
        {
            var targetRecord = _repository.GetByIdAsync(entry.Id).Result;
            var exists = targetRecord != null;

            if (exists)
            {
                entry.UpdatedAt = DateTime.UtcNow;
                await _repository.UpdateAsync(entry);
                return;
            }

            entry.CreatedAt = DateTime.UtcNow;
            await _repository.InsertAsync(entry);
        }

        public async Task RemoveAsync(Guid id)
        {
            var label = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(label);
        }
    }
}
