using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class AddEditMaintenanceTaskForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();
        private readonly int? _taskId;
        public event EventHandler MaintenanceTaskSaved; 

        public AddEditMaintenanceTaskForm(int? taskId = null)
        {
            InitializeComponent();
            _taskId = taskId;
            this.Load += AddEditMaintenanceTaskForm_Load;
        }

        private async void AddEditMaintenanceTaskForm_Load(object sender, EventArgs e)
        {
            await LoadData();

            if (_taskId.HasValue)
            {
                await LoadTaskAsync(_taskId.Value);
            }
        }

        private async Task LoadData()
        {
            try
            {
                var rooms = await _context.Rooms.ToListAsync();
                cmbRoom.DataSource = rooms;
                cmbRoom.DisplayMember = "room_number";
                cmbRoom.ValueMember = "room_id";

                var employees = await _context.Employees.ToListAsync();
                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "last_name";
                cmbEmployee.ValueMember = "employee_id";

                cmbPriority.Items.Clear();
                cmbPriority.Items.AddRange(new[] { "Низкий","Средний","Высокий","Критический" });

                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new[] { "Запланировано","В процессе","Выполнено","Отменено" });

                cmbPriority.SelectedIndex = 1;
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTaskAsync(int taskId)
        {
            try
            {
                var task = await _context.MaintenanceTasks.FindAsync(taskId);
                if (task == null)
                {
                    MessageBox.Show($"Задача с ID {taskId} не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmbRoom.SelectedValue = task.room_id;
                cmbEmployee.SelectedValue = task.employee_id;
                txtDescription.Text = task.task_description ?? string.Empty;
                cmbPriority.SelectedItem = task.priority;
                dateScheduled.Value = task.scheduled_date;
                nudCost.Value = task.cost ?? 0;
                cmbStatus.SelectedItem = task.status;
                txtNotes.Text = task.notes ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке задачи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedItem == null ||
                cmbEmployee.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                cmbPriority.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_taskId.HasValue)
                {
                    var task = await _context.MaintenanceTasks.FindAsync(_taskId.Value);
                    if (task == null) return;

                    task.room_id = (int)cmbRoom.SelectedValue;
                    task.employee_id = (int)cmbEmployee.SelectedValue;
                    task.task_description = txtDescription.Text.Trim();
                    task.priority = cmbPriority.SelectedItem?.ToString() ?? "Средний";
                    task.scheduled_date = dateScheduled.Value;
                    task.cost = nudCost.Value;
                    task.status = cmbStatus.SelectedItem?.ToString() ?? "Запланировано";
                    task.notes = txtNotes.Text.Trim();
                }
                else
                {
                    var task = new MaintenanceTask
                    {
                        room_id = (int)cmbRoom.SelectedValue,
                        employee_id = (int)cmbEmployee.SelectedValue,
                        task_description = txtDescription.Text.Trim(),
                        priority = cmbPriority.SelectedItem?.ToString() ?? "Средний",
                        scheduled_date = dateScheduled.Value,
                        cost = nudCost.Value,
                        status = cmbStatus.SelectedItem?.ToString() ?? "Запланировано",
                        notes = txtNotes.Text.Trim()
                    };
                    _context.MaintenanceTasks.Add(task);
                }

                await _context.SaveChangesAsync();

                MaintenanceTaskSaved?.Invoke(this, EventArgs.Empty);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}
