using System.Collections.Generic;
using System.Threading.Tasks;
using BestBulgarianMovies.Services.Models.Articles;
using BestBulgarianMovies.Services.Models.Blog;

namespace BestBulgarianMovies.Services.Interfaces.Articles
{
    public interface IArticlesService
    {
        Task<IEnumerable<ArticlesListingServiceModel>> FindAsync(string searchText);

        Task<IEnumerable<ArticlesListingServiceModel>> AllAsync(int page = 1);

        Task<ArticlesListingServiceModel> ById(int id);

        Task<int> TotalAsync();
    }
}
