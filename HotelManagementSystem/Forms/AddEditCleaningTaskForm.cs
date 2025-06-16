using HotelManagementSystem.Models;
using HotelManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class AddEditCleaningTaskForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();
        private readonly int? _taskId;
        public event EventHandler CleaningTaskSaved;

        public AddEditCleaningTaskForm(int? taskId = null)
        {
            InitializeComponent();
            _taskId = taskId;
            this.Load += AddEditCleaningTaskForm_Load;
        }

        private async void AddEditCleaningTaskForm_Load(object sender, EventArgs e)
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
                comboRoom.DataSource = rooms;
                comboRoom.DisplayMember = "room_number";
                comboRoom.ValueMember = "room_id";

                var employees = await _context.Employees.ToListAsync();
                comboEmployee.DataSource = employees;
                comboEmployee.DisplayMember = "last_name";
                comboEmployee.ValueMember = "employee_id";

                comboTaskType.Items.Clear();
                comboTaskType.Items.AddRange(new[] { "Стандартная", "Глубокая", "Техническое обслуживание" });

                if (comboTaskType.Items.Count > 0)
                    comboTaskType.SelectedIndex = 0;

                chkIsActive.Checked = true;
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
                var task = await _context.CleaningTasks.FindAsync(taskId);
                if (task == null)
                {
                    MessageBox.Show($"Задача с ID {taskId} не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comboRoom.SelectedValue = task.room_id;
                comboEmployee.SelectedValue = task.employee_id;
                comboTaskType.SelectedItem = task.task_type;
                dateTimePicker.Value = task.scheduled_date;
                numericEstimatedDuration.Value = task.estimated_duration ?? 0;
                txtNotes.Text = task.notes ?? string.Empty;
                chkIsActive.Checked = task.status == "Запланировано";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке задачи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (comboRoom.SelectedValue == null || comboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите номер и сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_taskId.HasValue)
                {
                    var task = await _context.CleaningTasks.FindAsync(_taskId.Value);
                    if (task == null) return;

                    task.room_id = (int)comboRoom.SelectedValue;
                    task.employee_id = (int)comboEmployee.SelectedValue;
                    task.task_type = comboTaskType.SelectedItem?.ToString() ?? "Стандартная";
                    task.scheduled_date = dateTimePicker.Value;
                    task.estimated_duration = (int)numericEstimatedDuration.Value;
                    task.notes = txtNotes.Text.Trim();
                    task.status = chkIsActive.Checked ? "Запланировано" : "Отменено";
                }
                else
                {
                    var task = new CleaningTask
                    {
                        room_id = (int)comboRoom.SelectedValue,
                        employee_id = (int)comboEmployee.SelectedValue,
                        task_type = comboTaskType.SelectedItem?.ToString() ?? "Стандартная",
                        scheduled_date = dateTimePicker.Value,
                        estimated_duration = (int)numericEstimatedDuration.Value,
                        notes = txtNotes.Text.Trim(),
                        status = "Запланировано"
                    };
                    _context.CleaningTasks.Add(task);
                }

                await _context.SaveChangesAsync();

                CleaningTaskSaved?.Invoke(this, EventArgs.Empty);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }

}