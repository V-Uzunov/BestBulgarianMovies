namespace BestBulgarianMovies.Web.Models.Home
{
    using BestBulgarianMovies.Services.Models.Movies;
    using System.Collections.Generic;

    public class HomeIndexViewModel
    {
        public IEnumerable<MovieListingServiceModel> Movies { get; set; }

        public string SearchText { get; set; }
    }
}