namespace BestBulgarianMovies.Web.Areas.Admin.Controllers
{
    using BestBulgarianMovies.Web.Infrastructure.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.Administrator)]
    public class BaseAdminController : Controller
    {
    }
}