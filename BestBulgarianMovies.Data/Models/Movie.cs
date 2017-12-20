namespace BestBulgarianMovies.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MovieTitleMinLenght)]
        [MaxLength(DataConstants.MovieTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MovieDescriptionMinLenght)]
        public string Description { get; set; }
        
        [MaxLength(DataConstants.MovieAgeRestrictionMax)]
        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string Cast { get; set; }

        public GenreTypes Genre { get; set; }

        [Required]
        [MinLength(DataConstants.MovieVideoIdMinAndMaxLenght)]
        [MaxLength(DataConstants.MovieVideoIdMinAndMaxLenght)]
        public string VideoId { get; set; }

        [Required]
        [MaxLength(DataConstants.MovieThumbnailUrlMaxLenght)]
        public string ThumbnailUrl { get; set; }

        public ICollection<UserMovie> Users { get; set; } = new List<UserMovie>();
    }
}
