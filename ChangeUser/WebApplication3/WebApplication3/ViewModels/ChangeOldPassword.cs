using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class ChangeOldPassword
    {
        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ReNewPassword { get; set; }
    }
}
