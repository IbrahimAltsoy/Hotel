using Hotel.EntitiyLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hotel.DataAccessLayer.Context
{
    public class Context : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Stuff> Stuffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


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
