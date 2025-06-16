using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Forms
{
    public partial class PasswordHashGeneratorForm : Form
    {
        private readonly IUserService _userService;

        public PasswordHashGeneratorForm()
        {
            InitializeComponent();
            _userService = new UserService();

            Load += async (s, e) => await LoadEmployeesAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            using var context = DbContextFactory.CreateContext();

            var employees = await context.Employees
                .Select(e => new
                {
                    e.employee_id,
                    FullName = $"{e.last_name} {e.first_name[0]}. {(string.IsNullOrEmpty(e.middle_name) ? "" : e.middle_name[0] + ".")}"
                })
                .ToListAsync();

            cboEmployee.DataSource = employees;
            cboEmployee.DisplayMember = "FullName";
            cboEmployee.ValueMember = "employee_id";
        }

        private async void BtnGenerateAndSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string hash = PasswordHasher.HashPassword(password);
                int employeeId = (int)cboEmployee.SelectedValue;

                var user = new User
                {
                    username = username,
                    password_hash = hash,
                    role = cboRole.SelectedItem?.ToString() ?? "Ресепшен",
                    employee_id = employeeId,
                    is_active = true
                };

                await _userService.CreateUserAsync(user);

                MessageBox.Show("Пользователь создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cboEmployee.SelectedIndex = -1; 
            cboRole.SelectedIndex = -1;     
            txtUsername.Focus();           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}