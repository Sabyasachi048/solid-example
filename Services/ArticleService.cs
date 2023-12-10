using AutoMapper;
using SolidExample.Models.BOs;
using SolidExample.Models.Entities;
using System.Linq.Expressions;

namespace SolidExample.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IBaseService<Article> _service;
        private readonly IMapper _mapper;

        public ArticleService(IBaseService<Article> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task AddOrUpdate(ArticleBO entry)
        {
            await _service.AddOrUpdateAsync(_mapper.Map<Article>(entry));
        }
        public async Task<IEnumerable<ArticleBO>> GetAsync()
        {
            var result = _mapper.Map<IEnumerable<ArticleBO>>(await _service.GetAsync());
            return result;
            
        }
        public async Task<ArticleBO> GetById(Guid id)
        {
            return _mapper.Map<ArticleBO>(await _service.GetByIdAsync(id));
        }
        public async Task Remove(Guid id)
        {
            await _service.RemoveAsync(id); 
        }
        public IEnumerable<ArticleBO> Where(Expression<Func<Article, bool>> exp)
        {
            var whereResult = _service.Where(exp);
            return _mapper.Map<IEnumerable<ArticleBO>>(whereResult);
        }
    }
}
