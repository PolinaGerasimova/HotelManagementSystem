using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelManagementContext _context;

        public RoomService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms
                .Include(r => r.cleaningTask)
                .Include(r => r.maintenanceTask)
                .Include(r => r.bookings)
                .ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(r => r.cleaningTask)
                .Include(r => r.maintenanceTask)
                .Include(r => r.bookings)
                .FirstOrDefaultAsync(r => r.room_id == id);
        }

        public async Task<Room> CreateRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task DeleteRoomAsync(int id)
        {
            //var room = await _context.Rooms.FindAsync(id);
            //if (room != null)
            //{
            //    _context.Rooms.Remove(room);
            //    await _context.SaveChangesAsync();
            //}

            var room = await _context.Rooms
                .Include(r => r.cleaningTask)
                .Include(r => r.maintenanceTask)
                .Include(r => r.bookings)
                .FirstOrDefaultAsync(r => r.room_id == id);
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms
                .Include(r => r.cleaningTask)
                .Include(r => r.maintenanceTask)
                .Include(r => r.bookings)
                .Where(r => r.status == "Available")
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> SearchRoomsAsync(string searchTerm)
        {
            return await _context.Rooms
                .Where(r => r.room_number.Contains(searchTerm) ||
                           r.category.CategoryName.Contains(searchTerm))
                .ToListAsync();
        }
    }
} 