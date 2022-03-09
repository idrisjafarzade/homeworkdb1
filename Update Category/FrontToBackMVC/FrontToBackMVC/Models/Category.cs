using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontToBackMVC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        public bool IsMain { get; set; }

        public bool IsDeleted { get; set; }

        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
