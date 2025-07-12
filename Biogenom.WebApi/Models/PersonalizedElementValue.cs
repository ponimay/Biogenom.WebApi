using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.WebApi.Models
{
    public class PersonalizedElementValue
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string ElementName { get; set; }
        public double ValueFromSet { get; set; }
        public double ValueFromFood { get; set; }
        public string Unit { get; set; }
        [ForeignKey("ReportId")]
        public NutritionReport Report { get; set; }
    }
} 