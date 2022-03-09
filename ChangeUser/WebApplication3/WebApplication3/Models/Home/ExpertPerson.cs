using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models.Home
{
    public class ExpertPerson
    {
        public int Id { get; set; } 

        public string ImgName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }


    }
}
