namespace BestBulgarianMovies.Web.Areas.Blog.Controllers
{
    using Web.Controllers;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Html;
    using Services.Interfaces.Blog;
    using System.Threading.Tasks;
    using Web.Areas.Blog.Models.Articles;
    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Extensions;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public ArticlesController(IBlogArticleService articles,
            UserManager<User> userManager,
            IHtmlService html)
        {
            this.articles = articles;
            this.userManager = userManager;
            this.html = html;
        }
        
        //GET: /Blog/Articles/Create
        public IActionResult Create()
            => this.View();

        //Post: /Blog/Articles/Create
        [HttpPost]
        public async Task<IActionResult> Create(ArticleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(model.Title, model.Content, model.ThumbnailUrl,  userId);

            return RedirectToAction(
                nameof(Web.Controllers.ArticlesController.Index),
                "Articles",
                new { area = string.Empty });
        }

        //GET: /Blog/Articles/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var articlesFindById = await this.articles.ById(id);

            if (articlesFindById == null)
            {
                return NotFound();
            }

            return View(new ArticleFormModel
            {
                Title = articlesFindById.Title,
                Content = articlesFindById.Content,
                ThumbnailUrl = articlesFindById.ThumbnailUrl
            });
        }

        //Post: /Blog/Articles/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ArticleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.articles.EditAsync(id,
                                          model.Title,
                                          model.Content,
                                          model.ThumbnailUrl);

            TempData.AddSuccessMessage($"Article {model.Title} successfully edited!");

            return RedirectToAction(
                nameof(Web.Controllers.ArticlesController.Index),
                "Articles",
                new { area = string.Empty });
        }

        //GET: /Blog/Articles/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var articleFindById = await this.articles.ById(id);

            if (articleFindById == null)
            {
                return NotFound();
            }

            return View(new ArticleFormModel
            {
                Id = articleFindById.Id,
                Title = articleFindById.Title,
                Content = articleFindById.Content,
                ThumbnailUrl = articleFindById.ThumbnailUrl
            });
        }

        //POST: /Blog/Articles/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var articleId = await this.articles.ById(id);

            if (articleId == null)
            {
                return NotFound();
            }

            await this.articles.DeleteAsync(id);

            TempData.AddSuccessMessage($"Article {articleId.Title} successfully deleted!");

            return RedirectToAction(
                nameof(Web.Controllers.ArticlesController.Index),
                "Articles",
                new { area = string.Empty });
        }
    }
}
