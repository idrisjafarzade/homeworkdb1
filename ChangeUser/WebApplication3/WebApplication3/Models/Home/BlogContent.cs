using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Home
{
    public class BlogContent
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "bos ola bilmez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "bos ola bilmez")]
        public string ImgName { get; set; }

        [Required(ErrorMessage = "bos ola bilmez")]
        public DateTime dateTime { get; set; }

        [Required(ErrorMessage = "bos ola bilmez")]
        public string Text { get; set; }
    }
}
