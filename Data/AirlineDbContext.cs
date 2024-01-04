using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Flight entity
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flights");
                entity.HasKey(e => e.Id);
                // Additional configurations can be added here
            });

            // Configure the Ticket entity
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(e => e.Id);

                // Define the relationship between Ticket and Flight
                entity.HasOne<Flight>() // Ticket has one Flight
                    .WithMany() // Flight has many Tickets
                    .HasForeignKey(t => t.FlightIdFK); // The foreign key in Ticket

                // Additional configurations can be added here
            });

            // Add further configurations as needed
        }
    }
}

