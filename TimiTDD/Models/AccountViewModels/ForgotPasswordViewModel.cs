using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}