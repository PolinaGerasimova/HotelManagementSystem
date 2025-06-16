using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public interface IBookingServiceItemService
    {
        Task<IEnumerable<BookingServiceItem>> GetServicesByBookingIdAsync(int bookingId);
        Task<BookingServiceItem> GetServiceByIdAsync(int serviceId);
        Task<BookingServiceItem> AddServiceAsync(BookingServiceItem serviceItem);
        Task<BookingServiceItem> UpdateServiceAsync(BookingServiceItem serviceItem);
        Task DeleteServiceAsync(int serviceId);
    }
}
