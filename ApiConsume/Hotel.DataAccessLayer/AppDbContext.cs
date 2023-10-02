using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Stuff> Stuffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O97PCTN\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
