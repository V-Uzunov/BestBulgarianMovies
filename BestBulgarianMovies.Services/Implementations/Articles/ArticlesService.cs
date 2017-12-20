namespace BestBulgarianMovies.Services.Implementations.Articles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Services.Interfaces.Articles;
    using BestBulgarianMovies.Services.Models.Articles;
    using BestBulgarianMovies.Services.Models.Blog;
    using Microsoft.EntityFrameworkCore;

    public class ArticlesService : IArticlesService
    {
        private readonly BestBulgarianMoviesDbContext db;

        public ArticlesService(BestBulgarianMoviesDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ArticlesListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Articles
                .OrderByDescending(c => c.Id)
                .Where(c => c.Title.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<ArticlesListingServiceModel>()
                .ToListAsync();
        }


        public async Task<IEnumerable<ArticlesListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Articles
                .OrderByDescending(a => a.PublishDate)
                .Skip((page - 1) * ServiceConstants.BlogArticlesPageSize)
                .Take(ServiceConstants.BlogArticlesPageSize)
                .ProjectTo<ArticlesListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
            => await this.db.Articles.CountAsync();

        public async Task<ArticlesListingServiceModel> ById(int id)
             => await this.db
                 .Articles
                 .Where(a => a.Id == id)
                 .ProjectTo<ArticlesListingServiceModel>()
                 .FirstOrDefaultAsync();
    }
}
