using Microsoft.EntityFrameworkCore;
namespace Biogenom.WebApi.Models
{
    public class BiogenomDbContext : DbContext
    {
        public BiogenomDbContext(DbContextOptions<BiogenomDbContext> options) : base(options) { }

        public DbSet<NutritionReport> NutritionReports { get; set; }
        public DbSet<NutritionElement> NutritionElements { get; set; }
        public DbSet<PersonalizedSetItem> PersonalizedSetItems { get; set; }
        public DbSet<PersonalizedElementValue> PersonalizedElementValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
} 