using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAngularRestaurantServer.Api.DataAccess.Context;
using MyAngularRestaurantServer.Api.DataAccess.Entities;
using MyAngularRestaurantServer.Api.Dtos;

namespace MyAngularRestaurantServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations
                .OrderByDescending(x => x.ReservationDate)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(
            ReservationDto reservationDto)
        {
            var reservation = new Reservation
            {
                Name = reservationDto.Name,
                Email = reservationDto.Email,
                ReservationDate = reservationDto.ReservationDate,
                PersonCount = reservationDto.PersonCount,
                SpecialRequest = reservationDto.SpecialRequest
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetReservation),
                new { id = reservation.ReservationId },
                reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(
            int id,
            ReservationDto reservationDto)
        {
            if (id != reservationDto.ReservationId)
            {
                return BadRequest("Reservation id bilgisi uyuşmuyor.");
            }

            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            reservation.Name = reservationDto.Name;
            reservation.Email = reservationDto.Email;
            reservation.ReservationDate = reservationDto.ReservationDate;
            reservation.PersonCount = reservationDto.PersonCount;
            reservation.SpecialRequest = reservationDto.SpecialRequest;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}