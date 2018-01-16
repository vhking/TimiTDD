using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TimiTDD.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
         // Add profile data for application users by adding properties to the ApplicationUser class
        [Required(ErrorMessage = "Ansatt Id må fylles inn")]
        [Display(Name = "Ansatt Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Navn på ansatt må fylles inn")]
        [StringLength(255)]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [StringLength(255)]
        [Display(Name = "Gatenavn")]
        public string Addr { get; set; }

        [StringLength(255)]
        [Display(Name = "Postnummer")]
        public string ZIP { get; set; }

        [StringLength(255)]
        [Display(Name = "Poststed")]
        public string City { get; set; }

        [StringLength(255)]
        [Display(Name = "Stilling")]
        public string Title { get; set; }
    }
}
