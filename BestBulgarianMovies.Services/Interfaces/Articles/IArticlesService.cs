namespace BestBulgarianMovies.Services.Interfaces.Articles
{
    using BestBulgarianMovies.Services.Models.Articles;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        Task<IEnumerable<ArticlesListingServiceModel>> FindAsync(string searchText);

        Task<IEnumerable<ArticlesListingServiceModel>> AllAsync(int page = 1);

        Task<ArticlesListingServiceModel> ById(int id);

        Task<int> TotalAsync();
    }
}