namespace BestBulgarianMovies.Services.Models.Movies
{
    using AutoMapper;
    using BestBulgarianMovies.Common.Mapping;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MovieDetailsServiceModel : IMapFrom<Movie>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MovieTitleMinLenght)]
        [MaxLength(DataConstants.MovieTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MovieDescriptionMinLenght)]
        public string Description { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string Cast { get; set; }

        public GenreTypes Genre { get; set; }

        [Required]
        [MinLength(DataConstants.MovieVideoIdMinAndMaxLenght)]
        [MaxLength(DataConstants.MovieVideoIdMinAndMaxLenght)]
        public string VideoId { get; set; }

        [MaxLength(DataConstants.MovieThumbnailUrlMaxLenght)]
        public string ThumbnailUrl { get; set; }

        public int Users { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper
            .CreateMap<Movie, MovieDetailsServiceModel>()
            .ForMember(m => m.Users, cfg => cfg.MapFrom(m => m.Users.Count));
    }
}
