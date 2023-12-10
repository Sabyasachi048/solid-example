using AutoMapper;
using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService<User> _service;
        private readonly IMapper _mapper;

        public UserService(IBaseService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task AddOrUpdateAsync(UserBO entry)
        {
            await _service.AddOrUpdateAsync(_mapper.Map<User>(entry));
        }
        public async Task<IEnumerable<UserBO>> GetAsync()
        {
            var result = _mapper.Map<IEnumerable<UserBO>>(await _service.GetAsync());
            return result;

        }
        public async Task<UserBO> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UserBO>(await _service.GetByIdAsync(id));
        }
        public async Task RemoveAsync(Guid id)
        {
            await _service.RemoveAsync(id);
        }
        public IEnumerable<UserBO> Where(Expression<Func<User, bool>> exp)
        {
            var whereResult = _service.Where(exp);
            return _mapper.Map<IEnumerable<UserBO>>(whereResult);
        }

        public string SendEmail(string email)
        {
            var user = _service.Where(user => user.Email == email).First();
            return $"Welcome {user.DisplayName}!";
        }
    }
}
