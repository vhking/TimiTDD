using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models
{
    class Client
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Display(Name ="Navn")]
        public string Name { get; set; }     
        [Display(Name ="Gatenavn")]
        public string Addr { get; set; }
        [Display(Name ="Postnr.")]
        public string ZIP { get; set; }
        [Display(Name ="Poststed")]
        public string City { get; set; }
        [Display(Name ="E-post")]
        public string Email { get; set; }
        [Display(Name ="Org.")]
        public string Org { get; set; }
    }
    
}