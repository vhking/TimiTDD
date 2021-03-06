using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimiTDD.Models
{
    public class WorkParticipation
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Dato")]
        public DateTime? DateTimeStart { get; set; }
        [Display(Name="Dato")]
        public DateTime? DateTimeEnd { get; set; }
        [Display(Name="Timer")]
        public double? Hours { get; set; }
        [Display(Name="Pause")]
        public double? WorkBreak { get; set; }
        [Display(Name="Kommentar")]
        public string Comment { get; set; }        
        public bool Session { get; set; } 
        
        [ForeignKey("CId")]
        [Display(Name = "Kleint")]
        public int? ClientId { get; set; }
        public Client CId { get; set; }
        
        [ForeignKey("PId")]
        [Display(Name = "Prosjekt id")]
        public int? ProjectId { get; set; }
        public Project PId { get; set; }

        [Required]
        [ForeignKey("UId")]
        public string UserId { get; set; }
        public ApplicationUser UId { get; set; }
        
        [ForeignKey("ATId")]
        [Display(Name = "Aktivitet type")]
        public int? ActivityTypeId { get; set; }
        public ActivityType ATId { get; set; }

        [ForeignKey("WCId")]
        [Display(Name = "Arbeid utført")]
        public int? WorkCategoryId { get; set; }
        public WorkCategory WCId { get; set; }
        
        [ForeignKey("AId")]
        [Display(Name = "Fraværsgrunn")]
        public int? AbsenceId { get; set; }
        public AbsenceCategory AId { get; set; }

    }
}