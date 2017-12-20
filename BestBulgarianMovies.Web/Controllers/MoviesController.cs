namespace BestBulgarianMovies.Web.Controllers
{
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Services.Interfaces.Movies;
    using BestBulgarianMovies.Services.Models.Movies;
    using BestBulgarianMovies.Web.Infrastructure.Extensions;
    using BestBulgarianMovies.Web.Models.Movies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MoviesController : Controller
    {
        private readonly IMovieService movies;
        private readonly UserManager<User> userManager;

        public MoviesController(IMovieService movies,
            UserManager<User> userManager)
        {
            this.movies = movies;
            this.userManager = userManager;
        }

        //GET: /Movies/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var model = new MovieDetailsViewModel
            {
                Movies = await this.movies.ByIdAsync<MovieDetailsServiceModel>(id)
            };

            if (model.Movies == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = this.userManager.GetUserId(User);

                model.ItsLiked =
                    await this.movies.UserFavoriteMovie(id, userId);
            }

            return View(model);
        }

        //POST: /Movies/Like/{id}
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.movies.UserLikeAsync(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("You like this movie!");

            return RedirectToAction(nameof(Details), new { id });
        }

        //POST: /Movies/Dislike/{id}
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Dislike(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.movies.UserDislikeAsync(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddErrorMessage("You dislike this movie!");

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}