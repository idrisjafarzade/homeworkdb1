using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }  
        
        [Required,DataType(DataType.Password)]
        public string Password { get; set; } 

        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set;}
    }
}
