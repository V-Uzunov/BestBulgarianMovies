namespace BestBulgarianMovies.Web.Areas.Admin.Models.Users
{
    using BestBulgarianMovies.Services.Models.Admin;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class UsersListingViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
