using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models.AccountViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}