namespace BestBulgarianMovies.Services.Models.Admin
{
    using BestBulgarianMovies.Common.Mapping;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminMovieServiceView : IMapFrom<Movie>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MovieTitleMinLenght, ErrorMessage = "Title minimum length is 2")]
        [MaxLength(DataConstants.MovieTitleMaxLenght, ErrorMessage = "Title maximum length is 50")]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MovieDescriptionMinLenght, ErrorMessage = "Description minimum length is 50")]
        public string Description { get; set; }

        [Display(Name = "Age Restriction")]
        [Range(0, DataConstants.MovieAgeRestrictionMax)]
        public int? AgeRestriction { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        [Display(Name = "Special Characters in Movie")]
        public string Cast { get; set; }

        public GenreTypes Genre { get; set; }

        [Required]
        [MinLength(DataConstants.MovieVideoIdMinAndMaxLenght)]
        [MaxLength(DataConstants.MovieVideoIdMinAndMaxLenght)]
        [Display(Name = "Video ID")]
        public string VideoId { get; set; }

        [MaxLength(DataConstants.MovieThumbnailUrlMaxLenght, ErrorMessage = "Thumbnail URL maximum length is 2047")]
        [Display(Name = "Thumbnail URL")]
        public string ThumbnailUrl { get; set; }
    }
}
