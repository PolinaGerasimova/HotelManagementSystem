using System;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize DbContextFactory with connection string
            var connectionString = "Server=localhost;Database=hotel_management;User=root;Password=root;";
            DbContextFactory.Initialize(connectionString);

            Application.Run(new Forms.LoginForm());
        }
    }
}