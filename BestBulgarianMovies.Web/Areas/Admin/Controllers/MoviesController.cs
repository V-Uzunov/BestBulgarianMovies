namespace BestBulgarianMovies.Web.Areas.Admin.Controllers
{
    using BestBulgarianMovies.Services.Interfaces.Admin;
    using BestBulgarianMovies.Services.Models.Admin;
    using BestBulgarianMovies.Web.Controllers;
    using BestBulgarianMovies.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MoviesController : BaseAdminController
    {
        private readonly IAdminMovieService movie;

        public MoviesController(IAdminMovieService movie)
        {
            this.movie = movie;
        }

        //GET: /Admin/Movies/Create
        public IActionResult Create()
            => View();

        //POST: Admin/Movies/Create
        [HttpPost]
        public async Task<IActionResult> Create(AdminMovieServiceView model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await this.movie
                 .CreateAsync(model.Title,
                              model.Description,
                              model.AgeRestriction,
                              model.ReleaseDate,
                              model.Director,
                              model.Cast,
                              model.Genre,
                              model.VideoId,
                              model.ThumbnailUrl);

            TempData.AddSuccessMessage($"Movie {model.Title} successfully added!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        //GET: /Admin/Movies/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var movieId = await this.movie.FindById(id);

            if (movieId == null)
            {
                return NotFound();
            }

            return View(new AdminMovieServiceView
            {
                Id = movieId.Id,
                Title = movieId.Title,
                AgeRestriction = movieId.AgeRestriction,
                Cast = movieId.Cast,
                Description = movieId.Description,
                Director = movieId.Director,
                Genre = movieId.Genre,
                ReleaseDate = movieId.ReleaseDate,
                ThumbnailUrl = movieId.ThumbnailUrl,
                VideoId = movieId.VideoId
            });
        }

        //POST: /Admin/Movies/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdminMovieServiceView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.movie
                 .EditAsync(id,
                              model.Title,
                              model.Description,
                              model.AgeRestriction,
                              model.ReleaseDate,
                              model.Director,
                              model.Cast,
                              model.Genre,
                              model.VideoId,
                              model.ThumbnailUrl);

            TempData.AddSuccessMessage($"Movie {model.Title} successfully edited!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        //GET: /Admin/Movies/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var movieId = await this.movie.FindById(id);

            if (movieId == null)
            {
                return NotFound();
            }

            return View(new AdminMovieServiceView
            {
                Id = movieId.Id,
                Title = movieId.Title,
                AgeRestriction = movieId.AgeRestriction,
                Cast = movieId.Cast,
                Description = movieId.Description,
                Director = movieId.Director,
                Genre = movieId.Genre,
                ReleaseDate = movieId.ReleaseDate,
                ThumbnailUrl = movieId.ThumbnailUrl,
                VideoId = movieId.VideoId
            });
        }

        //POST: /Admin/Movies/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var movieId = await this.movie.FindById(id);

            if (movieId == null)
            {
                return NotFound();
            }

            await this.movie.DeleteAsync(id);

            TempData.AddSuccessMessage($"Movie {movieId.Title} successfully deleted!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }
    }
}