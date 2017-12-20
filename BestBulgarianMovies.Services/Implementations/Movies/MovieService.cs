namespace BestBulgarianMovies.Services.Implementations.Movies
{
    using AutoMapper.QueryableExtensions;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Services.Interfaces.Movies;
    using BestBulgarianMovies.Services.Models.Movies;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MovieService : IMovieService
    {
        private readonly BestBulgarianMoviesDbContext db;

        public MovieService(BestBulgarianMoviesDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<MovieListingServiceModel>> AllMovieAsync()
            => await this.db
            .Movies
            .ProjectTo<MovieListingServiceModel>()
            .ToListAsync();

        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
        => await this.db
            .Movies
            .Where(m => m.Id == id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> UserDislikeAsync(int movieId, string userId)
        {
            var movieInfo = await this.GetMovieInfo(movieId, userId);

            if (movieInfo == null || !movieInfo.ItsLiked)
            {
                return false;
            }

            var userWithMovies = await this.db
                .FindAsync<UserMovie>(userId, movieId);

            this.db.Remove(userWithMovies);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UserLikeAsync(int movieId, string userId)
        {
            var movieInfo = await this.GetMovieInfo(movieId, userId);

            if (movieInfo == null || movieInfo.ItsLiked)
            {
                return false;
            }

            var userWithMovie = new UserMovie
            {
                MovieId = movieId,
                UserId = userId
            };

            this.db.Add(userWithMovie);

            await this.db.SaveChangesAsync();

            return true;
        }

        private async Task<MovieWithUserInfo> GetMovieInfo(int movieId, string userId)
        => await this.db
                .Movies
                .Where(m => m.Id == movieId)
                .Select(c => new MovieWithUserInfo
                {
                    ItsLiked = c.Users.Any(s => s.UserId == userId)
                })
                .FirstOrDefaultAsync();

        public async Task<bool> UserFavoriteMovie(int movieId, string userId)
        => await this.db
                .Movies
                .AnyAsync(c => c.Id == movieId && c.Users.Any(s => s.UserId == userId));

        public async Task<IEnumerable<MovieListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Movies
                .OrderByDescending(c => c.Id)
                .Where(c => c.Title.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<MovieListingServiceModel>()
                .ToListAsync();
        }
    }
}
