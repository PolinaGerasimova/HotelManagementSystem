using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagementSystem;

namespace HotelManagementSystem.Services
{
    public class MaintenanceTaskService : IMaintenanceTaskService
    {
        private readonly HotelManagementContext _context;

        public MaintenanceTaskService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceTask>> GetAllMaintenanceTasksAsync()
        {
            return await _context.MaintenanceTasks
                .Include(mt => mt.room)
                .Include(mt => mt.employee)
                .ToListAsync();
        }

        public async Task<MaintenanceTask> GetMaintenanceTaskByIdAsync(int id)
        {
            return await _context.MaintenanceTasks
                .Include(mt => mt.room)
                .Include(mt => mt.employee)
                .FirstOrDefaultAsync(mt => mt.task_id == id);
        }

        public async Task<MaintenanceTask> CreateMaintenanceTaskAsync(MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Add(maintenanceTask);
            await _context.SaveChangesAsync();
            return maintenanceTask;
        }

        public async Task<MaintenanceTask> UpdateMaintenanceTaskAsync(MaintenanceTask maintenanceTask)
        {
            _context.Entry(maintenanceTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return maintenanceTask;
        }

        public async Task DeleteMaintenanceTaskAsync(int id)
        {
            var maintenanceTask = await _context.MaintenanceTasks.FindAsync(id);
            if (maintenanceTask != null)
            {
                _context.MaintenanceTasks.Remove(maintenanceTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByDateAsync(DateTime date)
        {
            return await _context.MaintenanceTasks
                .Include(mt => mt.room)
                .Include(mt => mt.employee)
                .Where(mt => mt.scheduled_date.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByStatusAsync(string status)
        {
            return await _context.MaintenanceTasks
                .Include(mt => mt.room)
                .Include(mt => mt.employee)
                .Where(mt => mt.status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByPriorityAsync(string priority)
        {
            return await _context.MaintenanceTasks
                .Where(t => t.priority == priority)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByRoomIdAsync(int room_id)
        {
            return await _context.MaintenanceTasks
                .Include(mt => mt.room)
                .Include(mt => mt.employee)
                .Where(mt => mt.room_id == room_id)
                .ToListAsync();
        }

        public async Task UpdateTaskStatus(int taskId, string status)
        {
            var task = await _context.MaintenanceTasks.FindAsync(taskId);
            if (task == null)
                throw new ArgumentException("Task not found");

            task.status = status;
            await _context.SaveChangesAsync();
        }
    }
} 