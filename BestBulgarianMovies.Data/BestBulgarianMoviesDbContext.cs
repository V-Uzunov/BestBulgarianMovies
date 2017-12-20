namespace BestBulgarianMovies.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BestBulgarianMoviesDbContext : IdentityDbContext<User>
    {
        public BestBulgarianMoviesDbContext(DbContextOptions<BestBulgarianMoviesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserFavorite { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<UserMovie>()
                .HasKey(um => new {  um.UserId, um.MovieId});

            builder
                .Entity<UserMovie>()
                .HasOne(u => u.Movie)
                .WithMany(m => m.Users)
                .HasForeignKey(u => u.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<UserMovie>()
                .HasOne(m => m.User)
                .WithMany(u => u.Movies)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Article>()
                .HasOne(u => u.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            

            base.OnModelCreating(builder);
        }
    }
}
