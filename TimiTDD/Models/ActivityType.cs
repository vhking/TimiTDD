using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models
{
    public class ActivityType
    {
        [Key]
        [Display(Name = "Aktivites ID")]
        public int Id { get; set; }
        [Display(Name = "Aktivitets type")]
        public string Activity { get; set; }
    }
}