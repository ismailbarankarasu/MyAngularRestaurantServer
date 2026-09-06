using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAngularRestaurantServer.Api.DataAccess.Context;
using MyAngularRestaurantServer.Api.DataAccess.Entities;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeaturesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeatures()
        {
            return await _context.Features.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
            var feature = await _context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(FeatureDto featureDto)
        {
            var feature = new Feature
            {
                Title = featureDto.Title,
                Description = featureDto.Description,
                ImageUrl = featureDto.ImageUrl,
                ButtonTitle = featureDto.ButtonTitle,
                ButtonUrl = featureDto.ButtonUrl
            };

            _context.Features.Add(feature);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFeature),
                new { id = feature.FeatureId },
                feature);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(int id, FeatureDto featureDto)
        {
            if (id != featureDto.FeatureId)
            {
                return BadRequest("Feature id bilgisi uyuşmuyor.");
            }

            var feature = await _context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            feature.Title = featureDto.Title;
            feature.Description = featureDto.Description;
            feature.ImageUrl = featureDto.ImageUrl;
            feature.ButtonTitle = featureDto.ButtonTitle;
            feature.ButtonUrl = featureDto.ButtonUrl;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var feature = await _context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}