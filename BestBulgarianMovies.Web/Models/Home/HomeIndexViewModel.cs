namespace BestBulgarianMovies.Web.Models.Home
{
    using BestBulgarianMovies.Services.Models.Movies;
    using System.Collections.Generic;

    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<MovieListingServiceModel> Movies { get; set; }
    }
}
