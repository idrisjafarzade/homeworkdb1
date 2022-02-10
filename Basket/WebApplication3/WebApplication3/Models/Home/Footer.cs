using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Home
{
    public class Footer
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string FacebookUrl { get; set; }

        [StringLength(100)]
        public string LinkedinUrl { get; set; }

    }
}
