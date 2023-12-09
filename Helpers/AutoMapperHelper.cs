using AutoMapper;
using SolidExample.Models.BOs;
using SolidExample.Models.DTOs;
using SolidExample.Models.Entities;

namespace SolidExample.Helpers
{
    public static class AutoMapperHelper
    {
        public static Action<IMapperConfigurationExpression> Configuration = cfg =>
        {
            cfg.CreateMap<BaseEntity, BaseEntityBO>()
                .ReverseMap();
            cfg.CreateMap<BaseEntityDto, BaseEntityBO>()
                .ReverseMap();
            cfg.CreateMap<User, UserBO>()
                .ReverseMap();
            cfg.CreateMap<UserDto, UserBO>()
                .ReverseMap();
            cfg.CreateMap<Author, AuthorBO>()
                .ReverseMap();
            cfg.CreateMap<AuthorDto, AuthorBO>()
                .ReverseMap();
            cfg.CreateMap<Article, ArticleBO>()
                .ReverseMap();
            cfg.CreateMap<ArticleDto, ArticleBO>()
                .ReverseMap();
        };
    }
}
