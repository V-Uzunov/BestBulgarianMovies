namespace BestBulgarianMovies.Services.Models.Blog
{
    using AutoMapper;
    using BestBulgarianMovies.Common.Mapping;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BlogArticleDetailsServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [MinLength(DataConstants.ArticleTitleMinLength)]
        [MaxLength(DataConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string ThumbnailUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Article, BlogArticleDetailsServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
