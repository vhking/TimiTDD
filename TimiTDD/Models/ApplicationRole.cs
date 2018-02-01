using Microsoft.AspNetCore.Identity;

namespace TimiTDD.Models
{
    public class ApplicationRole: IdentityRole
    {
         public string RoleDescription { get; set; }
    }
}
