using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class ResetPassword
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }   
    }
}
