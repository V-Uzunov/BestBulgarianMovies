namespace BestBulgarianMovies.Services.Implementations.Blog
{
    using AutoMapper.QueryableExtensions;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Services.Interfaces.Blog;
    using BestBulgarianMovies.Services.Models.Blog;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogArticleService : IBlogArticleService
    {
        private readonly BestBulgarianMoviesDbContext db;

        public BlogArticleService(BestBulgarianMoviesDbContext db)
        {
            this.db = db;
        }

        public async Task<BlogArticleDetailsServiceModel> ById(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<BlogArticleDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task CreateAsync(string title, string content, string thumbnailUrl, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                ThumbnailUrl = thumbnailUrl,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string content, string thumbnailUrl)
        {
            var articleId = await this.db.Articles.FindAsync(id);

            if (articleId == null)
            {
                return;
            }

            articleId.Title = title;
            articleId.Content = content;
            articleId.ThumbnailUrl = thumbnailUrl;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var articleId = await this.db.Articles.FindAsync(id);

            if (articleId == null)
            {
                return;
            }

            this.db.Articles.Remove(articleId);
            await this.db.SaveChangesAsync();
        }
    }
}