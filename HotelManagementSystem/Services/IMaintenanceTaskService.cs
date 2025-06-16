using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public interface IMaintenanceTaskService
    {
        Task<IEnumerable<MaintenanceTask>> GetAllMaintenanceTasksAsync();
        Task<MaintenanceTask> GetMaintenanceTaskByIdAsync(int id);
        Task<MaintenanceTask> CreateMaintenanceTaskAsync(MaintenanceTask maintenanceTask);
        Task<MaintenanceTask> UpdateMaintenanceTaskAsync(MaintenanceTask maintenanceTask);
        Task DeleteMaintenanceTaskAsync(int id);
        Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByDateAsync(DateTime date);
        Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByStatusAsync(string status);
        Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByPriorityAsync(string priority);
        Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByRoomIdAsync(int roomId);
        Task UpdateTaskStatus(int taskId, string status);
    }
} 