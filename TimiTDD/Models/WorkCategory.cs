using System.ComponentModel.DataAnnotations;

namespace TimiTDD.Models
{
    public class WorkCategory
    {
        [Key]
        [Display(Name = "Arbeid ID")]   
        public int Id { get; set; }
        [Display(Name="Arbeid utført")]
        public string WorkPerformed { get; set; }
        public string WorkCategoryIdAndWorkPreformed
        {
            get
            {
                return this.Id + " . " + this.WorkPerformed;
            }
        }
        
    }
}