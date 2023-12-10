using Microsoft.EntityFrameworkCore;
using SolidExample.Models;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ISolidExampleDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ISolidExampleDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(Guid guid)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == guid);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _entities.Where(exp);
        }


        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            var oldEntity = await _entities.FindAsync(entity.Id);
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            } 

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
