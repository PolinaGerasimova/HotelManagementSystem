using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public static class CurrentUser
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static int? EmployeeId { get; set; }

        public static bool IsAdmin => Role == "Администратор";
        public static bool IsReceptionist => Role == "Ресепшен";
        public static bool IsHousekeeper => Role == "Горничная";
        public static bool IsTechnician => Role == "Техник";
    }
}
