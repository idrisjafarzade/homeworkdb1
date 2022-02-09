using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Home
{
    public class Header
    {
        public int Id { get; set; }

        [Required]
        public string Logo { get; set; }

    

    }
}
