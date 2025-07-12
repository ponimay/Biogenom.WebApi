using System;
using System.Collections.Generic;

namespace Biogenom.WebApi.Models
{
    public class NutritionReportDto
    {
        public DateTime CreatedAt { get; set; }
        public List<NutritionElementDto> Elements { get; set; }
        public List<PersonalizedSetItemDto> PersonalizedSet { get; set; }
        public List<PersonalizedElementValueDto> PersonalizedElementValues { get; set; }
    }

    public class NutritionElementDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double? NormMin { get; set; }
        public double? NormMax { get; set; }
        public string Unit { get; set; }
        public bool IsDeficit { get; set; }
    }

    public class PersonalizedSetItemDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class PersonalizedElementValueDto
    {
        public string ElementName { get; set; }
        public double ValueFromSet { get; set; }
        public double ValueFromFood { get; set; }
        public string Unit { get; set; }
    }
} 