using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAngularRestaurantServer.Api.DataAccess.Context;
using MyAngularRestaurantServer.Api.DataAccess.Entities;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactInfosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetContactInfos()
        {
            return await _context.ContactInfos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> GetContactInfo(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);

            if (contactInfo == null)
                return NotFound();

            return contactInfo;
        }

        [HttpPost]
        public async Task<ActionResult<ContactInfo>> PostContactInfo(ContactInfoDto dto)
        {
            var contactInfo = new ContactInfo
            {
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                OpeningHours = dto.OpeningHours
            };

            _context.ContactInfos.Add(contactInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetContactInfo),
                new { id = contactInfo.ContactInfoId },
                contactInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactInfo(int id, ContactInfoDto dto)
        {
            if (id != dto.ContactInfoId)
                return BadRequest("ContactInfo id bilgisi uyuşmuyor.");

            var contactInfo = await _context.ContactInfos.FindAsync(id);

            if (contactInfo == null)
                return NotFound();

            contactInfo.Address = dto.Address;
            contactInfo.Phone = dto.Phone;
            contactInfo.Email = dto.Email;
            contactInfo.OpeningHours = dto.OpeningHours;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);

            if (contactInfo == null)
                return NotFound();

            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}