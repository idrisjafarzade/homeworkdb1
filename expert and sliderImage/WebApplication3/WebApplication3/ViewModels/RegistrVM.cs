﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class RegistrVM
    {
        [Required]
        public string FullName { get; set; }
       
        [Required ]
        public string UserName { get; set; }

        [Required,EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }   

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
     
        [Required,DataType(DataType.Password) ,Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
