using Microsoft.AspNetCore.Mvc;
using Biogenom.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Biogenom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutritionReportController : ControllerBase
    {
        private readonly BiogenomDbContext _context;
        public NutritionReportController(BiogenomDbContext context)
        {
            _context = context;
        }

        // Вывести последний отчёт
        [HttpGet("last")]
        public async Task<ActionResult<NutritionReportDto>> GetLastReport()
        {
            var report = await _context.NutritionReports
                .Include(r => r.Elements)
                .Include(r => r.PersonalizedSet)
                .Include(r => r.PersonalizedElementValues)
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync();

            if (report == null)
                return NotFound();

            var dto = new NutritionReportDto
            {
                CreatedAt = report.CreatedAt,
                Elements = report.Elements.Select(e => new NutritionElementDto
                {
                    Name = e.Name,
                    Value = e.Value,
                    NormMin = e.NormMin,
                    NormMax = e.NormMax,
                    Unit = e.Unit,
                    IsDeficit = e.IsDeficit
                }).ToList(),
                PersonalizedSet = report.PersonalizedSet.Select(p => new PersonalizedSetItemDto
                {
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                }).ToList(),
                PersonalizedElementValues = report.PersonalizedElementValues.Select(p => new PersonalizedElementValueDto
                {
                    ElementName = p.ElementName,
                    ValueFromSet = p.ValueFromSet,
                    ValueFromFood = p.ValueFromFood,
                    Unit = p.Unit
                }).ToList()
            };

            return Ok(dto);
        }

        // Новый отчёт
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] NutritionReportDto dto)
        {
            var report = new NutritionReport
            {
                CreatedAt = dto.CreatedAt,
                Elements = dto.Elements.Select(e => new NutritionElement
                {
                    Name = e.Name,
                    Value = e.Value,
                    NormMin = e.NormMin,
                    NormMax = e.NormMax,
                    Unit = e.Unit,
                    IsDeficit = e.IsDeficit
                }).ToList(),
                PersonalizedSet = dto.PersonalizedSet.Select(p => new PersonalizedSetItem
                {
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                }).ToList(),
                PersonalizedElementValues = dto.PersonalizedElementValues.Select(p => new PersonalizedElementValue
                {
                    ElementName = p.ElementName,
                    ValueFromSet = p.ValueFromSet,
                    ValueFromFood = p.ValueFromFood,
                    Unit = p.Unit
                }).ToList()
            };

            _context.NutritionReports.Add(report);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLastReport), new { id = report.Id }, null);
        }

        // Удалить последний отчёт
        [HttpDelete("last")]
        public async Task<IActionResult> DeleteLastReport()
        {
            var report = await _context.NutritionReports
                .Include(r => r.Elements)
                .Include(r => r.PersonalizedSet)
                .Include(r => r.PersonalizedElementValues)
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync();

            if (report == null)
                return NotFound();

            _context.NutritionReports.Remove(report);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Преимущества приема БАДов
        [HttpGet("benefits")]
        public IActionResult GetBenefits()
        {
            var benefits = new[]
            {
                "Устраняют витаминно-минеральный дефицит",
                "Улучшают усвоение полезных веществ из пищи",
                "Компенсируют несбалансированное питание",
                "Обеспечивают организм жизненно важными элементами",
                "Повышают функциональные резервы организма"
            };
            return Ok(new { benefits });
        }
    }
} 