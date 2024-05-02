using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using airpangea_back.Models;
using Microsoft.EntityFrameworkCore;

namespace airpangea_back.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Passengers)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Bookings)
                .WithOne(b => b.Flight)
                .HasForeignKey(b => b.FlightId);

            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Bookings)
                .WithOne(b => b.Passenger)
                .HasForeignKey(b => b.PassengerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

/*
La relación User <--> Passenger podría ser M:M
porque un porque varios usuarios podrian meter el mismo pasajero 
(o no si tienen id diferente por lo que no serían el mismo pasajero).
*/