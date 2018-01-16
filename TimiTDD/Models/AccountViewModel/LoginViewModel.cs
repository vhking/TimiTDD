using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models.AccountViewModel
{
    public class LoginViewModel
    {
        
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Husk meg?")]
        public bool RememberMe { get; set; }
    }
}