namespace BestBulgarianMovies.Services.Implementations.Users
{
    using AutoMapper.QueryableExtensions;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Services.Interfaces.Users;
    using BestBulgarianMovies.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly BestBulgarianMoviesDbContext db;

        public UserService(BestBulgarianMoviesDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Users
                .OrderBy(u => u.UserName)
                .Where(u => u.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<UserListingServiceModel>()
                .ToListAsync();
        }
    }
}