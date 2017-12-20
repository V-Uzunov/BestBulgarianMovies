namespace BestBulgarianMovies.Web.Areas.Blog.Models.Articles
{
    using BestBulgarianMovies.Data;
    using System.ComponentModel.DataAnnotations;

    public class ArticleFormModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ArticleTitleMinLength)]
        [MaxLength(DataConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(DataConstants.ArticleThumbnailMaxLenght)]
        public string ThumbnailUrl { get; set; }

        [Required]
        [MinLength(DataConstants.ArticleContentMinLenght)]
        public string Content { get; set; }
    }
}