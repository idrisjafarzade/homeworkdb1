using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models.Home
{
    public class SliderImgIcons
    {
        public int Id { get; set; }
       
        public string ImgName { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        [NotMapped]
        public IFormFile[] Photos { get; set; }

    }
}
