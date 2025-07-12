using System;
using System.Collections.Generic;

namespace Biogenom.WebApi.Models
{
    public class NutritionReport
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<NutritionElement> Elements { get; set; }
        public List<PersonalizedSetItem> PersonalizedSet { get; set; }
        public List<PersonalizedElementValue> PersonalizedElementValues { get; set; }
    }
} 