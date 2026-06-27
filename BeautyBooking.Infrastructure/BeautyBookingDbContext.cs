using BeautyBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.Infrastructure
{
    public class BeautyBookingDbContext : DbContext
    {
        public BeautyBookingDbContext(DbContextOptions<BeautyBookingDbContext> options)
            : base(options)
        {
        }

        // Tabela Services na podstawie klasy Service.
        public DbSet<Service> Services { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ReservationItem> ReservationItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReservationItem>()
    .HasKey(rs => new { rs.ReservationId, rs.ServiceId });

            modelBuilder.Entity<ReservationItem>()
                .HasOne(rs => rs.Reservation)
                .WithMany(r => r.ReservationItems)
                .HasForeignKey(rs => rs.ReservationId);

            modelBuilder.Entity<ReservationItem>()
                .HasOne(rs => rs.Service)
                .WithMany(s => s.ReservationItems)
                .HasForeignKey(rs => rs.ServiceId);
            modelBuilder.Entity<User>()
    .HasOne(x => x.Client)
    .WithOne()
    .HasForeignKey<User>(x => x.ClientId)
    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Employee)
                .WithOne()
                .HasForeignKey<User>(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
