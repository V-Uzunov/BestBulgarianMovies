namespace BestBulgarianMovies.Services.Models.Admin
{
    using BestBulgarianMovies.Common.Mapping;
    using BestBulgarianMovies.Data.Models;

    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}