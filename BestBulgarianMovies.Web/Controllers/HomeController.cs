namespace BestBulgarianMovies.Web.Controllers
{
    using BestBulgarianMovies.Services.Interfaces.Articles;
    using BestBulgarianMovies.Services.Interfaces.Movies;
    using BestBulgarianMovies.Web.Models;
    using BestBulgarianMovies.Web.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IMovieService movies;
        private readonly IArticlesService articles;

        public HomeController(IMovieService movies, IArticlesService articles)
        {
            this.movies = movies;
            this.articles = articles;
        }
        
        public async Task<IActionResult> Index()
           => View(new HomeIndexViewModel
           {
               Movies = await this.movies.AllMovieAsync()
           });

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText
            };

            viewModel.Movies = await this.movies.FindAsync(model.SearchText);

            viewModel.Articles = await this.articles.FindAsync(model.SearchText);

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
