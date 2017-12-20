namespace BestBulgarianMovies.Services.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Services.Interfaces.Admin;
    using BestBulgarianMovies.Services.Models.Admin;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminMovieService : IAdminMovieService
    {
        private readonly BestBulgarianMoviesDbContext db;

        public AdminMovieService(BestBulgarianMoviesDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title,
            string description,
            int? ageRestriction,
            DateTime releaseDate,
            string director,
            string cast,
            GenreTypes genre,
            string videoId,
            string thumbnailUrl)
        {
            var movie = new Movie
            {
                Title=title,
                Description=description,
                AgeRestriction=ageRestriction,
                ReleaseDate=releaseDate,
                Director=director,
                Cast=cast,
                Genre=genre,
                VideoId=videoId,
                ThumbnailUrl=thumbnailUrl
            };

            await this.db.Movies.AddAsync(movie);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movieId = await this.db.Movies.FindAsync(id);

            if (movieId == null)
            {
                return;
            }

            this.db.Movies.Remove(movieId);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id,
            string title,
            string description,
            int? ageRestriction,
            DateTime releaseDate,
            string director,
            string cast,
            GenreTypes genre, 
            string videoId,
            string thumbnailUrl)
        {
            var movieExist = await this.db.Movies.FindAsync(id);

            if (movieExist == null)
            {
                return;
            }

            movieExist.AgeRestriction = ageRestriction;
            movieExist.Cast = cast;
            movieExist.Description = description;
            movieExist.Director = director;
            movieExist.Genre = genre;
            movieExist.ReleaseDate = releaseDate;
            movieExist.ThumbnailUrl = thumbnailUrl;
            movieExist.Title = title;
            movieExist.VideoId = videoId;

            await this.db.SaveChangesAsync();
        }

        public async Task<AdminMovieServiceView> FindById(int id)
            => await this.db
            .Movies
            .Where(m => m.Id == id)
            .ProjectTo<AdminMovieServiceView>()
            .FirstOrDefaultAsync();
    }
}
