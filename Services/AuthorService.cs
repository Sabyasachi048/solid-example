using AutoMapper;
using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBaseService<Author> _service;
        private readonly IMapper _mapper;

        public AuthorService(IBaseService<Author> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task AddOrUpdate(AuthorBO entry)
        {
            await _service.AddOrUpdateAsync(_mapper.Map<Author>(entry));
        }
        public async Task<IEnumerable<AuthorBO>> GetAsync()
        {
            var result = _mapper.Map<IEnumerable<AuthorBO>>(await _service.GetAsync());
            return result;

        }
        public async Task<AuthorBO> GetById(Guid id)
        {
            return _mapper.Map<AuthorBO>(await _service.GetByIdAsync(id));
        }
        public async Task Remove(Guid id)
        {
            await _service.RemoveAsync(id);
        }
        public IEnumerable<AuthorBO> Where(Expression<Func<Author, bool>> exp)
        {
            var whereResult = _service.Where(exp);
            return _mapper.Map<IEnumerable<AuthorBO>>(whereResult);
        }
    }
}
