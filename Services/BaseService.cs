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
            return await _repository.GetAll();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _repository.Where(exp);
        }

        public async Task AddOrUpdateAsync(T entry)
        {
            var targetRecord = _repository.GetById(entry.Id).Result;
            var exists = targetRecord != null;

            if (exists)
            {
                entry.UpdatedAt = DateTime.UtcNow;
                await _repository.Update(entry);
                return;
            }

            entry.CreatedAt = DateTime.UtcNow;
            await _repository.Insert(entry);
        }

        public async Task RemoveAsync(Guid id)
        {
            var label = await _repository.GetById(id);
            await _repository.Delete(label);
        }
    }
}
