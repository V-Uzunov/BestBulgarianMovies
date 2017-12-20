namespace BestBulgarianMovies.Services.Models.Movies
{
    using BestBulgarianMovies.Common.Mapping;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MovieListingServiceModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MovieTitleMinLenght)]
        [MaxLength(DataConstants.MovieTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MovieDescriptionMinLenght)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public GenreTypes Genre { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}
