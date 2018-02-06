using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimiTDD.Models.AccountViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

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

        [Required]
        [EmailAddress]
        [Display(Name = "E-Post")]
        public string UserName { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public string RoleId { get; set; }
    }
    
}