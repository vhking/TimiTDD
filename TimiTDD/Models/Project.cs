using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimiTDD.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Prosjekt id")]
        public int ProjectId { get; set; }
        [Display(Name = "Prosjekt Navn")]
        public string ProjectName { get; set; }
        [Display(Name = "Start dato")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Slutt dato")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Mur")]
        public double EstimateMasonry { get; set; }
        [Display(Name = "Flis")]
        public double EstimateTile { get; set; }
        [Display(Name = "Råbygg")]
        public double EstimateStructural { get; set; }
        [Display(Name = "Utvendig")]
        public double EstimateExternal { get; set; }
        [Display(Name = "Plating")]
        public double EstimatePlating { get; set; }
        [Display(Name = "Iso og stendr.")]
        public double EstimateStender { get; set; }
        [Display(Name = "Sluttarb.")]
        public double EstimateFinalisingWork { get; set; }
        [Display(Name = "Car/gar")]
        public double EstimateGarage { get; set; }
        [Display(Name = "Montering")]
        public double EstimateAssembly { get; set; }
        [Display(Name = "Annet")]
        public double EstimateOther { get; set; }

        public string ProjectIdAndName
        {
            get
            {
                return "Prosjekt " + this.ProjectId + " . " + this.ProjectName;
            }
        }
    }
}