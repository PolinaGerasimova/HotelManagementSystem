using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class BookingServiceItemService : IBookingServiceItemService
    {
        private readonly HotelManagementContext _context;

        public BookingServiceItemService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingServiceItem>> GetServicesByBookingIdAsync(int bookingId)
        {
            return await _context.BookingServices
                .Where(bs => bs.booking_id == bookingId)
                .Include(bs => bs.service)
                .ToListAsync();
        }

        public async Task<BookingServiceItem> GetServiceByIdAsync(int serviceId)
        {
            return await _context.BookingServices
                .Include(bs => bs.service)
                .FirstOrDefaultAsync(bs => bs.booking_service_id == serviceId);
        }

        public async Task<BookingServiceItem> AddServiceAsync(BookingServiceItem serviceItem)
        {
            _context.BookingServices.Add(serviceItem);
            await _context.SaveChangesAsync();
            return serviceItem;
        }

        public async Task<BookingServiceItem> UpdateServiceAsync(BookingServiceItem serviceItem)
        {
            _context.Entry(serviceItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return serviceItem;
        }

        public async Task DeleteServiceAsync(int serviceId)
        {
            var item = await _context.BookingServices.FindAsync(serviceId);
            if (item != null)
            {
                _context.BookingServices.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
