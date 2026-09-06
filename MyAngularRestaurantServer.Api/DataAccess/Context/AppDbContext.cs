using Microsoft.EntityFrameworkCore;
using MyAngularRestaurantServer.Api.DataAccess.Entities;

namespace MyAngularRestaurantServer.Api.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
