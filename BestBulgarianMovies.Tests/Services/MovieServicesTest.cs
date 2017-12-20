namespace BestBulgarianMovies.Tests.Services
{
    using BestBulgarianMovies.Services.Implementations.Movies;
    using Data;
    using Data.Models;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class MovieServicesTest
    {
        public MovieServicesTest()
        {
            Tests.Initialize();
        }

        [Fact]
        public async Task FindAsyncShouldReturnCorrectResultWithFilter()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstMovie = new Movie { Id = 1, Title = "First", Cast= "First", Description= "First", Director= "First", ReleaseDate=DateTime.Now, ThumbnailUrl= "First", VideoId= "First" };

            var secondMovie = new Movie { Id = 2, Title = "Second", Cast = "Second Cast", Description = "Second Second Second", Director = "Second Director", ReleaseDate = DateTime.Now, ThumbnailUrl = "Second 1", VideoId = "Second 1"};

            var thirdMovie = new Movie { Id = 3, Title = "Third", Cast = "Third Cast", Description = "Third Third Third", Director = "Third Director", ReleaseDate = DateTime.Now, ThumbnailUrl = "Third 3", VideoId = "Third 3"};

            db.AddRange(firstMovie, secondMovie, thirdMovie);

            await db.SaveChangesAsync();

            var movieService = new MovieService(db);

            // Act
            var result = await movieService.FindAsync("F");

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == 1);
        }

        private BestBulgarianMoviesDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<BestBulgarianMoviesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BestBulgarianMoviesDbContext(dbOptions);
        }
    }
}
