namespace BestBulgarianMovies.Tests.Web.Admin.Controllers
{
    using BestBulgarianMovies.Web.Areas.Blog.Controllers;
    using BestBulgarianMovies.Web.Infrastructure.Constants;
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;

    public class ArticlesControllerTests
    {
        [Fact]
        public void ArticlesControllerMustBeInBlogArea()
        {
            // Arrange
            var controller = typeof(ArticlesController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.BlogArea);
        }

        [Fact]
        public void ArticlesControllerMustBeOnlyForBlogAuthors()
        {
            // Arrange
            var controller = typeof(ArticlesController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.BlogAuthorRole);
        }
    }
}