using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public interface ICleaningTaskService
    {
        Task<IEnumerable<CleaningTask>> GetAllCleaningTasksAsync();
        Task<CleaningTask> GetCleaningTaskByIdAsync(int id);
        Task<CleaningTask> CreateCleaningTaskAsync(CleaningTask cleaningTask);
        Task<CleaningTask> UpdateCleaningTaskAsync(CleaningTask cleaningTask);
        Task DeleteCleaningTaskAsync(int id);
        Task<IEnumerable<CleaningTask>> GetCleaningTasksByDateAsync(DateTime date);
        Task<IEnumerable<CleaningTask>> GetCleaningTasksByStatusAsync(string status);
        Task<IEnumerable<CleaningTask>> GetCleaningTasksByRoomIdAsync(int roomId);
        Task UpdateTaskStatus(int taskId, string status);
    }
} 