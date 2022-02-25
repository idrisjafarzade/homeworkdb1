using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Home
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="bos ola bilmez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "bos ola bilmez")]
        public double Price { get; set; }

        [Required(ErrorMessage = "bos ola bilmez")]
        public string Image { get; set; }

        [Required(ErrorMessage ="bos ola bilmez")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
