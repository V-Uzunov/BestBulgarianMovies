namespace BestBulgarianMovies.Tests.Web.Admin.Controllers
{
    using BestBulgarianMovies.Web.Areas.Admin.Controllers;
    using BestBulgarianMovies.Web.Infrastructure.Constants;
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;

    public class MoviesControllerTests
    {
        [Fact]
        public void MoviesControllerMustBeInAdminArea()
        {
            // Arrange
            var controller = typeof(MoviesController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.AdminArea);
        }

        [Fact]
        public void MoviesControllerMustBeOnlyForAdministrators()
        {
            // Arrange
            var controller = typeof(MoviesController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(WebConstants.Administrator);
        }
    }
}
