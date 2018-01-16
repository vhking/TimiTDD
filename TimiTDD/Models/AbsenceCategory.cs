using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models
{
    class AbsenceCategory
    {
        [Key]
        public int Id { get; set; } 
        [Display(Name="Fraværsgrunn")]
        public string AbsenceReason { get; set; }
        
    }
    
}