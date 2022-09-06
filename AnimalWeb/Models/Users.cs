using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace AnimalWeb.Models
{
    public class Users
    {
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public IList<AuthenticationScheme>? ExternalLogins { get; set; }

    }
}
