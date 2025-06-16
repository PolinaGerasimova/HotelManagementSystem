using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class EmployeesForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();

        public EmployeesForm()
        {
            InitializeComponent();
            LoadEmployeesAsync();
        }

        private async void LoadEmployeesAsync(string searchTerm = "")
        {
            try
            {
                var query = _context.Employees.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(e =>
                        e.first_name.Contains(searchTerm) ||
                        e.last_name.Contains(searchTerm) ||
                        e.middle_name.Contains(searchTerm));
                }

                var employees = await query.ToListAsync();

                var employeeList = employees.Select(e => new
                {
                    e.employee_id,
                    e.first_name,
                    e.last_name,
                    MiddleName = string.IsNullOrEmpty(e.middle_name) ? string.Empty : e.middle_name,
                    e.role,
                    e.phone_number,
                    EmploymentDate = e.employment_date.ToShortDateString(),
                    WorkSchedule = e.work_schedule ?? string.Empty
                }).ToList();

                employeesDataGridView.DataSource = employeeList;

                if (employeesDataGridView.Columns["employee_id"] != null)
                    employeesDataGridView.Columns["employee_id"].Visible = false;

                employeesDataGridView.Columns["first_name"].HeaderText = "Имя";
                employeesDataGridView.Columns["last_name"].HeaderText = "Фамилия";
                employeesDataGridView.Columns["MiddleName"].HeaderText = "Отчество";
                employeesDataGridView.Columns["role"].HeaderText = "Должность";
                employeesDataGridView.Columns["phone_number"].HeaderText = "Телефон";
                employeesDataGridView.Columns["EmploymentDate"].HeaderText = "Дата приема";
                employeesDataGridView.Columns["WorkSchedule"].HeaderText = "График работы";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditEmployeeForm();
            addEdit.FormClosed += (s, a) => LoadEmployeesAsync();
            addEdit.ShowDialog();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (employeesDataGridView.CurrentRow != null)
            {
                int employeeId = (int)employeesDataGridView.CurrentRow.Cells["employee_id"].Value;
                var addEdit = new AddEditEmployeeForm(employeeId);
                var result = addEdit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadEmployeesAsync();
                }
            }
        }

        private async void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (employeesDataGridView.CurrentRow != null)
            {
                int employeeId = (int)employeesDataGridView.CurrentRow.Cells["employee_id"].Value;
                var employee = await _context.Employees.FindAsync(employeeId);

                if (employee != null)
                {
                    if (MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.Employees.Remove(employee);
                        await _context.SaveChangesAsync();
                        LoadEmployeesAsync();
                    }
                }
            }
        }
    }
}


