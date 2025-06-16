using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelManagementSystem
{
    public class HotelManagementContext : DbContext
    {
        public DbSet<RoomCategory> RoomCategories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CleaningTask> CleaningTasks { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        public DbSet<BookingServiceItem> BookingServices { get; set; }

        public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
                .HasIndex(r => r.room_number)
                .IsUnique();

            modelBuilder.Entity<Guest>()
                .HasIndex(g => g.passport_number)
                .IsUnique();

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.guest)
                .WithMany(g => g.bookings)
                .HasForeignKey(b => b.guest_id);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.room)
                .WithMany(r => r.bookings)
                .HasForeignKey(b => b.room_id);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.category)
                .WithMany(c => c.Rooms)
                .HasForeignKey(r => r.category_id);

            modelBuilder.Entity<BookingServiceItem>()
                .HasOne(bs => bs.booking)
                .WithMany(b => b.booking_services)
                .HasForeignKey(bs => bs.booking_id);

            modelBuilder.Entity<BookingServiceItem>()
                .HasOne(bs => bs.service)
                .WithMany(s => s.booking_services)
                .HasForeignKey(bs => bs.service_id);

            modelBuilder.Entity<CleaningTask>()
                .Property(e => e.task_type)
                .HasColumnType("VARCHAR(255)")
                .HasDefaultValue("Standard");

            modelBuilder.Entity<CleaningTask>()
                .Property(e => e.status)
                .HasColumnType("VARCHAR(255)")
                .HasDefaultValue("Scheduled");

            modelBuilder.Entity<CleaningTask>()
                .Property(e => e.notes)
                .HasColumnType("TEXT");

            modelBuilder.Entity<CleaningTask>()
                .HasOne(ct => ct.room)
                .WithMany(r => r.cleaningTask) 
                .HasForeignKey(ct => ct.room_id);

            modelBuilder.Entity<CleaningTask>()
                .HasOne(ct => ct.employee)
                .WithMany(e => e.cleaningTask)  
                .HasForeignKey(ct => ct.employee_id);

            modelBuilder.Entity<MaintenanceTask>()
                .HasOne(mt => mt.room)
                .WithMany(r => r.maintenanceTask)
                .HasForeignKey(mt => mt.room_id);

            modelBuilder.Entity<MaintenanceTask>()
                .HasOne(mt => mt.employee)
                .WithMany(e => e.maintenanceTask)
                .HasForeignKey(mt => mt.employee_id);

        }
    }
}