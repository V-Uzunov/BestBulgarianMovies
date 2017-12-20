namespace BestBulgarianMovies.Services.Interfaces.Admin
{
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Services.Models.Admin;
    using System;
    using System.Threading.Tasks;

    public interface IAdminMovieService
    {
        Task CreateAsync(string title,
            string description,
            int? ageRestriction,
            DateTime releaseDate,
            string director,
            string cast,
            GenreTypes genre,
            string videoId,
            string thumbnailUrl);

        Task<AdminMovieServiceView> FindById(int id);

        Task EditAsync(int id,
            string title,
            string description,
            int? ageRestriction,
            DateTime releaseDate,
            string director,
            string cast,
            GenreTypes genre,
            string videoId,
            string thumbnailUrl);

        Task DeleteAsync(int id);
    }
}