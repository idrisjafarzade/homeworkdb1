using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Home
{
    public class User: IdentityUser
    {
        [Required]
        public string FullName { get; set; }
    }
}
