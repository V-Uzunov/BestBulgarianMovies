namespace BestBulgarianMovies.Services.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Services.Interfaces.Admin;
    using BestBulgarianMovies.Services.Models.Admin;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly BestBulgarianMoviesDbContext db;

        public AdminUserService(BestBulgarianMoviesDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            => await this.db
            .Users
            .ProjectTo<AdminUserListingServiceModel>()
            .ToListAsync();

        public async Task DeleteAsync(string userId)
        {
            var findUser = await this.db.Users.FindAsync(userId);

            if (findUser == null)
            {
                return;
            }

            this.db.Users.Remove(findUser);

            await this.db.SaveChangesAsync();
        }
    }
}
