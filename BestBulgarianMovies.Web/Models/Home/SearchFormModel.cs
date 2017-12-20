using System.ComponentModel.DataAnnotations;

namespace BestBulgarianMovies.Web.Models.Home
{
    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search In Articles")]
        public bool SearchInArticles { get; set; } = true;

        [Display(Name = "Search In Movies")]
        public bool SearchInMovies { get; set; } = true;
    }
}
