using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models
{
    public class AbsenceCategory
    {
        [Key]
        public int Id { get; set; } 
        [Display(Name="Fraværsgrunn")]
        public string AbsenceReason { get; set; }
        
    }
    
}