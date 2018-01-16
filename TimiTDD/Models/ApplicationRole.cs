using Microsoft.AspNetCore.Identity;

namespace TimiTDD.Models
{
    class ApplicationRole : IdentityRole
    {
         public string RoleDescription { get; set; }
    }
}