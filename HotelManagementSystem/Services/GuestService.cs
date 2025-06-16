using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class GuestService : IGuestService
    {
        private readonly HotelManagementContext _context;

        public GuestService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _context.Guests
                .Include(g => g.bookings)
                .ToListAsync();
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _context.Guests
                .Include(g => g.bookings)
                .FirstOrDefaultAsync(g => g.guest_id == id);
        }

        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task<Guest> UpdateGuestAsync(Guest guest)
        {
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task DeleteGuestAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Guest>> SearchGuestsAsync(string searchTerm)
        {
            return await _context.Guests
                .Where(g => g.first_name.Contains(searchTerm) ||
                           g.last_name.Contains(searchTerm) ||
                           g.email.Contains(searchTerm) ||
                           g.phone_number.Contains(searchTerm))
                .ToListAsync();
        }
    }
} 