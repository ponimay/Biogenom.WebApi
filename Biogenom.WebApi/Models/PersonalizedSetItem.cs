using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.WebApi.Models
{
    public class PersonalizedSetItem
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("ReportId")]
        public NutritionReport Report { get; set; }
    }
} 