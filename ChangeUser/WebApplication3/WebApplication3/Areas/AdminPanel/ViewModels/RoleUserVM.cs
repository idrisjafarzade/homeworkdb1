using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebApplication3.Areas.AdminPanel.ViewModels
{
    public class RoleUserVM
    {
        public List<IdentityRole> Roles { get; set; }
        public string  UserName { get; set; }   
    }
}
