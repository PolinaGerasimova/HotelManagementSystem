using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Models;
using HotelManagementSystem;
using Microsoft.EntityFrameworkCore;


namespace HotelManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly HotelManagementContext _context;

        public UserService()
        {
            _context = DbContextFactory.CreateContext();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.username == username);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            using var context = DbContextFactory.CreateContext();

            var existing = await context.Users.FirstOrDefaultAsync(u => u.username == user.username);
            if (existing != null)
                throw new Exception("Пользователь с таким логином уже существует");

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
