namespace BestBulgarianMovies.Web.Models.Movies
{
    using BestBulgarianMovies.Services.Models.Movies;

    public class MovieDetailsViewModel
    {
        public MovieDetailsServiceModel Movies { get; set; }

        public bool ItsLiked { get; set; }
    }
}