using Microsoft.EntityFrameworkCore;
using EventBooking.Models;
using System.Runtime;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace EventBooking.Bl
{
    public class EventDbContext:IdentityDbContext<ApplicationUser>
    {
        public EventDbContext()
        {
        }

        public EventDbContext(DbContextOptions<EventDbContext> options): base(options)
        {

        }


        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId);
                entity.HasOne(d => d.Category).WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId);
                entity.Property(e => e.Price)
                .HasPrecision(8, 2);
            });
            
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
            });
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(c=>c.bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(c=>c.bookings)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
