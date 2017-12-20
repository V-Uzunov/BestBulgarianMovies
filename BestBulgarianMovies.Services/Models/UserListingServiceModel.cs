namespace BestBulgarianMovies.Services.Models
{
    using AutoMapper;
    using BestBulgarianMovies.Common.Mapping;
    using BestBulgarianMovies.Data.Models;

    public class UserListingServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public int Movies { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<User, UserListingServiceModel>()
                .ForMember(u => u.Movies, cfg => cfg.MapFrom(u => u.Movies.Count));
    }
}
