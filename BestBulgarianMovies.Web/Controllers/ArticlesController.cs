namespace BestBulgarianMovies.Web.Controllers
{
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Services.Interfaces.Articles;
    using BestBulgarianMovies.Services.Interfaces.Blog;
    using BestBulgarianMovies.Web.Models.Articles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ArticlesController : Controller
    {
        private readonly IArticlesService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(IArticlesService articles,
            UserManager<User> userManager)
        {
            this.articles = articles;
            this.userManager = userManager;
        }

        //GET: /Articles/
        public async Task<IActionResult> Index(int page = 1)
            => View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            });

        //GET: /Articles/Details
        public async Task<IActionResult> Details(int id)
        {
            var articleWithId = await this.articles.ById(id);
            if (articleWithId == null)
            {
                return NotFound();
            }

            return this.View(articleWithId);
        }
    }
}
