using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public class CleaningTaskService : ICleaningTaskService
    {
        private readonly HotelManagementContext _context;

        public CleaningTaskService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CleaningTask>> GetAllCleaningTasksAsync()
        {
            return await _context.CleaningTasks
                .Include(ct => ct.room)
                .Include(ct => ct.employee)
                .ToListAsync();
        }

        public async Task<CleaningTask> GetCleaningTaskByIdAsync(int id)
        {
            return await _context.CleaningTasks
                .Include(ct => ct.room)
                .Include(ct => ct.employee)
                .FirstOrDefaultAsync(ct => ct.task_id == id);
        }

        public async Task<CleaningTask> CreateCleaningTaskAsync(CleaningTask cleaningTask)
        {
            _context.CleaningTasks.Add(cleaningTask);
            await _context.SaveChangesAsync();
            return cleaningTask;
        }

        public async Task<CleaningTask> UpdateCleaningTaskAsync(CleaningTask cleaningTask)
        {
            _context.Entry(cleaningTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cleaningTask;
        }

        public async Task DeleteCleaningTaskAsync(int id)
        {
            var cleaningTask = await _context.CleaningTasks.FindAsync(id);
            if (cleaningTask != null)
            {
                _context.CleaningTasks.Remove(cleaningTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CleaningTask>> GetCleaningTasksByDateAsync(DateTime date)
        {
            return await _context.CleaningTasks
                .Include(ct => ct.room)
                .Include(ct => ct.employee)
                .Where(ct => ct.scheduled_date.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<CleaningTask>> GetCleaningTasksByStatusAsync(string status)
        {
            return await _context.CleaningTasks
                .Include(ct => ct.room)
                .Include(ct => ct.employee)
                .Where(ct => ct.status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<CleaningTask>> GetCleaningTasksByRoomIdAsync(int roomId)
        {
            return await _context.CleaningTasks
              .Include(ct => ct.room)
              .Include(ct => ct.employee)
              .Where(ct => ct.room_id == roomId)
              .ToListAsync();
        }

        public async Task UpdateTaskStatus(int taskId, string status)
        {
            var task = await _context.CleaningTasks.FindAsync(taskId);
            if (task == null)
                throw new ArgumentException("Task not found");

            task.status = status;
            await _context.SaveChangesAsync();
        }
    }
} 