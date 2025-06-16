using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class AddEditEmployeeForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();
        private readonly int? _employeeId;
        public event EventHandler EmployeeSaved;

        public AddEditEmployeeForm(int? employeeId = null)
        {
            InitializeComponent();
            _employeeId = employeeId;

            if (_employeeId.HasValue)
                _ = LoadEmployeeAsync(_employeeId.Value);
        }

        private async Task LoadEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null) return;

            txtFirstName.Text = employee.first_name;
            txtLastName.Text = employee.last_name;
            txtMiddleName.Text = employee.middle_name;
            txtPhone.Text = employee.phone_number;
            txtRole.Text = employee.role;
            txtWorkSchedule.Text = employee.work_schedule;
            dtpEmploymentDate.Value = employee.employment_date;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtRole.Text))
            {
                MessageBox.Show("Поля 'Имя', 'Фамилия' и 'Должность' обязательны для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_employeeId.HasValue)
                {
                    var employee = await _context.Employees.FindAsync(_employeeId.Value);
                    if (employee == null) return;

                    employee.first_name = txtFirstName.Text.Trim();
                    employee.last_name = txtLastName.Text.Trim();
                    employee.middle_name = txtMiddleName.Text.Trim();
                    employee.phone_number = txtPhone.Text.Trim();
                    employee.role = txtRole.Text.Trim();
                    employee.work_schedule = txtWorkSchedule.Text.Trim();
                    employee.employment_date = dtpEmploymentDate.Value;
                }
                else
                {
                    var employee = new Employee
                    {
                        first_name = txtFirstName.Text.Trim(),
                        last_name = txtLastName.Text.Trim(),
                        middle_name = txtMiddleName.Text.Trim(),
                        phone_number = txtPhone.Text.Trim(),
                        role = txtRole.Text.Trim(),
                        work_schedule = txtWorkSchedule.Text.Trim(),
                        employment_date = dtpEmploymentDate.Value
                    };
                    _context.Employees.Add(employee);
                }

                await _context.SaveChangesAsync();
                EmployeeSaved?.Invoke(this, EventArgs.Empty);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

