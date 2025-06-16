using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HotelManagementContext _context;

        public EmployeeService(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.cleaningTask)
                .Include(e => e.maintenanceTask)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.cleaningTask)
                .Include(e => e.maintenanceTask)
                .FirstOrDefaultAsync(e => e.employee_id == id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.cleaningTask)
                .Include(e => e.maintenanceTask)
                .FirstOrDefaultAsync(e => e.employee_id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(string role)
        {
            return await _context.Employees
                .Where(e => e.role.Contains(role))
                .ToListAsync();
        }

        public async Task<bool> HasActiveTasksAsync(int employeeId)
        {
            bool hasCleaningTasks = await _context.CleaningTasks
                .AnyAsync(t => t.employee_id == employeeId && t.status != "Completed" && t.status != "Cancelled");

            bool hasMaintenanceTasks = await _context.MaintenanceTasks
                .AnyAsync(t => t.employee_id == employeeId && t.status != "Completed" && t.status != "Cancelled");

            return hasCleaningTasks || hasMaintenanceTasks;
        }
    }
}