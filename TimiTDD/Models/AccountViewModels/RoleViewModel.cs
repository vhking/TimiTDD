using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models.AccountViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Rollenavn")]
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

    }
    
}