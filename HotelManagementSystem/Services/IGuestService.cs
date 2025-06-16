using HotelManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest> GetGuestByIdAsync(int id);
        Task<Guest> CreateGuestAsync(Guest guest);
        Task<Guest> UpdateGuestAsync(Guest guest);
        Task DeleteGuestAsync(int id);
        Task<IEnumerable<Guest>> SearchGuestsAsync(string searchTerm);
    }
} 