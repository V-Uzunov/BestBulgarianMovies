namespace BestBulgarianMovies.Web.Models.Articles
{
    using BestBulgarianMovies.Services;
    using BestBulgarianMovies.Services.Models.Articles;
    using BestBulgarianMovies.Web.Models.Home;
    using System;
    using System.Collections.Generic;

    public class ArticleListingViewModel : SearchFormModel
    {
        public IEnumerable<ArticlesListingServiceModel> Articles { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / ServiceConstants.BlogArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
