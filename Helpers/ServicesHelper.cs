using SolidExample.Models;
using SolidExample.Models.Entities;
using SolidExample.Services;

namespace SolidExample.Helpers
{
    public static class ServicesHelper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ISolidExampleDbContext, SolidExampleDbContext>();
            
            services.AddAutoMapper(AutoMapperHelper.Configuration);

            services.AddTransient<IRepository<User>,Repository<User>>();
            services.AddTransient<IRepository<Author>,Repository<Author>>();
            services.AddTransient<IRepository<Article>,Repository<Article>>();

            services.AddTransient<IBaseService<User>,BaseService<User>>();
            services.AddTransient<IBaseService<Author>,BaseService<Author>>();
            services.AddTransient<IBaseService<Article>,BaseService<Article>>();

            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IArticleService, ArticleService>();
        }
    }
}
