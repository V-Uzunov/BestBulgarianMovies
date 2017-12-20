using System.ComponentModel.DataAnnotations;

namespace BestBulgarianMovies.Web.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}