namespace BestBulgarianMovies.Web.Models.Home
{
    using BestBulgarianMovies.Services.Models.Articles;
    using BestBulgarianMovies.Services.Models.Movies;
    using System.Collections.Generic;

    public class SearchViewModel
    {
        public IEnumerable<MovieListingServiceModel> Movies { get; set; }
            = new List<MovieListingServiceModel>();

        public IEnumerable<ArticlesListingServiceModel> Articles { get; set; }
            = new List<ArticlesListingServiceModel>();

        public string SearchText { get; set; }
    }
}