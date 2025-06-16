using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelManagementSystem.Services
{
    public static class DbContextFactory
    {
        private static Lazy<string> _connectionString = new Lazy<string>();

        public static void Initialize(string connectionString)
        {
            _connectionString = new Lazy<string>(() => connectionString);
        }

        public static HotelManagementContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelManagementContext>();
            optionsBuilder.UseMySql(
                _connectionString.Value,
                ServerVersion.AutoDetect(_connectionString.Value),
                mySqlOptions => mySqlOptions
                    .EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)
            );

            return new HotelManagementContext(optionsBuilder.Options);
        }
    }
} 