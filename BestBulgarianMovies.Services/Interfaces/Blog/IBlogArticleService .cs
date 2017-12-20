namespace BestBulgarianMovies.Services.Interfaces.Blog
{
    using BestBulgarianMovies.Services.Models.Blog;
    using System.Threading.Tasks;

    public interface IBlogArticleService
    {
        Task CreateAsync(string title, string content, string thumbnailUrl, string userId);
        
        Task<BlogArticleDetailsServiceModel> ById(int id);

        Task EditAsync(int id, string title, string content, string thumbnailUrl);
        
        Task DeleteAsync(int id);
    }
}
