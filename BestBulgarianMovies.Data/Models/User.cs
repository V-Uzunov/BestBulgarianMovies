namespace BestBulgarianMovies.Data.Models
{
    using Data;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<UserMovie> Movies { get; set; } = new List<UserMovie>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
