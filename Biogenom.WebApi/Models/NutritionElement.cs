using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.WebApi.Models
{
    public class NutritionElement
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double? NormMin { get; set; }
        public double? NormMax { get; set; }
        public string Unit { get; set; }
        public bool IsDeficit { get; set; }
        [ForeignKey("ReportId")]
        public NutritionReport Report { get; set; }
    }
} 