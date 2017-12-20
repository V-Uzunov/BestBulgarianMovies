namespace BestBulgarianMovies.Services.Models.Articles
{
    using AutoMapper;
    using BestBulgarianMovies.Common.Mapping;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArticlesListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [MinLength(DataConstants.ArticleTitleMinLength)]
        [MaxLength(DataConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string ThumbnailUrl { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Article, ArticlesListingServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}