namespace BestBulgarianMovies.Services.Interfaces.Movies
{
    using BestBulgarianMovies.Services.Models.Movies;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieService
    {
        Task<IEnumerable<MovieListingServiceModel>> AllMovieAsync();

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        Task<bool> UserFavoriteMovie(int movieId, string userId);

        Task<bool> UserLikeAsync(int movieId, string userId);

        Task<bool> UserDislikeAsync(int movieId, string userId);

        Task<IEnumerable<MovieListingServiceModel>> FindAsync(string searchText);
    }
}