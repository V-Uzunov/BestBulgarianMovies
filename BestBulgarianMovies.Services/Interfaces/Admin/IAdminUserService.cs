namespace BestBulgarianMovies.Services.Interfaces.Admin
{
    using BestBulgarianMovies.Services.Models.Admin;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();

        Task DeleteAsync(string userId);
    }
}
