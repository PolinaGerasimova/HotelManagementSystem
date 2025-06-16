using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem;

namespace HotelManagementSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly HotelManagementContext _context;

        public BookingService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.guest)
                .Include(b => b.room)
                .Include(b => b.booking_services)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.guest)
                .Include(b => b.room)
                .Include(b => b.booking_services)
                .FirstOrDefaultAsync(b => b.booking_id == id);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings
                .Where(b => b.check_in_date >= startDate && b.check_out_date <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByGuestIdAsync(int guest_id)
        {
            return await _context.Bookings
                .Include(b => b.guest)
                .Include(b => b.room)
                .Include(b => b.booking_services)
                .Where(b => b.guest_id == guest_id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByRoomIdAsync(int room_id)
        {
            return await _context.Bookings
                .Include(b => b.guest)
                .Include(b => b.room)
                .Include(b => b.booking_services)
                .Where(b => b.room_id == room_id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByStatusAsync(string status)
        {
            return await _context.Bookings
                .Include(b => b.guest)
                .Include(b => b.room)
                .Include(b => b.booking_services)
                .Where(b => b.status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetActiveBookingsAsync()
        {
            var today = DateTime.Today;
            return await _context.Bookings
                .Include(b => b.guest)
                .Include(b => b.room)
                .Include(b => b.booking_services)
                .Where(b => b.check_in_date <= today && b.check_out_date >= today)
                .ToListAsync();
        }

        public async Task UpdateBookingStatus(int bookingId, string status)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
                throw new ArgumentException("Booking not found");

            booking.status = status;
            await _context.SaveChangesAsync();
        }

    }
} 