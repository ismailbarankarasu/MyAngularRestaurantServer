using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAngularRestaurantServer.Api.DataAccess.Context;
using MyAngularRestaurantServer.Api.DataAccess.Entities;
using MyAngularRestaurantServer.Api.Dtos;
using MyAngularRestaurantServer.Api.Services;

namespace MyAngularRestaurantServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;

        public UsersController(
            AppDbContext context,
            PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            var existingUser = await _context.Users
                .AnyAsync(x => x.Email.ToLower() == email);

            if (existingUser)
            {
                return BadRequest(new
                {
                    message = "Bu e-posta adresi ile daha önce kayıt oluşturulmuş."
                });
            }

            var user = new User
            {
                NameSurname = dto.NameSurname.Trim(),
                Email = email
            };

            user.PasswordHash = _passwordService.HashPassword(
                user,
                dto.Password
            );

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var result = new UserDto
            {
                UserId = user.UserId,
                NameSurname = user.NameSurname,
                Email = user.Email
            };

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email);

            if (user == null)
            {
                return BadRequest(new
                {
                    message = "E-posta adresi veya şifre hatalı."
                });
            }

            var passwordValid = _passwordService.VerifyPassword(
                user,
                dto.Password
            );

            if (!passwordValid)
            {
                return BadRequest(new
                {
                    message = "E-posta adresi veya şifre hatalı."
                });
            }

            var result = new UserDto
            {
                UserId = user.UserId,
                NameSurname = user.NameSurname,
                Email = user.Email
            };

            return Ok(result);
        }
    }
}