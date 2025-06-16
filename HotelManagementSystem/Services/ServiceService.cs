using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class ServiceService : IServiceService
    {
        private readonly HotelManagementContext _context;

        public ServiceService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services
                .Include(s => s.booking_services)
                .ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services
                .Include(s => s.booking_services)
                .FirstOrDefaultAsync(s => s.service_id == id);
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service> UpdateServiceAsync(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Service>> SearchServicesAsync(string searchTerm)
        {
            return await _context.Services
                .Where(s => s.service_name.Contains(searchTerm) ||
                           s.description.Contains(searchTerm))
                .ToListAsync();
        }
    }
} 