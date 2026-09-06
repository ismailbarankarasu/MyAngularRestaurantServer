using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAngularRestaurantServer.Api.DataAccess.Context;
using MyAngularRestaurantServer.Api.DataAccess.Entities;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpPost]
        public async Task<ActionResult<Service>> PostService(ServiceDto serviceDto)
        {
            var service = new Service
            {
                Title = serviceDto.Title,
                Description = serviceDto.Description,
                Icon = serviceDto.Icon
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetService),
                new { id = service.ServiceId },
                service);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, ServiceDto serviceDto)
        {
            if (id != serviceDto.ServiceId)
            {
                return BadRequest("Service id bilgisi uyuşmuyor.");
            }

            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            service.Title = serviceDto.Title;
            service.Description = serviceDto.Description;
            service.Icon = serviceDto.Icon;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}