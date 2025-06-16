using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;

    namespace HotelManagementSystem
    {
    public partial class MaintenanceTasksForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();

        public MaintenanceTasksForm()
        {
            InitializeComponent();
            LoadMaintenanceTasksAsync();
        }

        private async void LoadMaintenanceTasksAsync()
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var tasks = await context.MaintenanceTasks
                        .Include(t => t.room)
                        .Include(t => t.employee)
                        .ToListAsync();

                    var table = new System.Data.DataTable();
                    table.Columns.Add("task_id", typeof(int));
                    table.Columns.Add("room_number", typeof(string));
                    table.Columns.Add("employee_name", typeof(string));
                    table.Columns.Add("task_description", typeof(string));
                    table.Columns.Add("priority", typeof(string));
                    table.Columns.Add("scheduled_date", typeof(string));
                    table.Columns.Add("completed_date", typeof(string));
                    table.Columns.Add("status", typeof(string));
                    table.Columns.Add("cost", typeof(decimal));
                    table.Columns.Add("notes", typeof(string));

                    foreach (var t in tasks)
                    {
                        var notes = t.notes;
                        table.Rows.Add(
                            t.task_id,
                            t.room.room_number,
                            $"{t.employee.last_name} {t.employee.first_name}",
                            t.task_description ?? string.Empty,
                            t.priority.ToString(),
                            t.scheduled_date.ToShortDateString(),
                            t.completed_date.HasValue ? t.completed_date.Value.ToShortDateString() : string.Empty,
                            t.status ?? string.Empty,
                            t.cost,
                            notes == null || notes is DBNull ? string.Empty : notes
                        );
                    }
                    maintenanceTasksDataGridView.DataSource = table;

                    if (maintenanceTasksDataGridView.Columns["task_id"] != null)
                        maintenanceTasksDataGridView.Columns["task_id"].Visible = false;

                    maintenanceTasksDataGridView.Columns["room_number"].HeaderText = "Номер комнаты";
                    maintenanceTasksDataGridView.Columns["employee_name"].HeaderText = "Сотрудник";
                    maintenanceTasksDataGridView.Columns["task_description"].HeaderText = "Описание задачи";
                    maintenanceTasksDataGridView.Columns["priority"].HeaderText = "Приоритет";
                    maintenanceTasksDataGridView.Columns["scheduled_date"].HeaderText = "Запланировано";
                    maintenanceTasksDataGridView.Columns["completed_date"].HeaderText = "Выполнено";
                    maintenanceTasksDataGridView.Columns["status"].HeaderText = "Статус";
                    maintenanceTasksDataGridView.Columns["cost"].HeaderText = "Стоимость";
                    maintenanceTasksDataGridView.Columns["notes"].HeaderText = "Примечания";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditMaintenanceTaskForm();
            addEdit.FormClosed += (s, a) => LoadMaintenanceTasksAsync();
            addEdit.ShowDialog();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (maintenanceTasksDataGridView.CurrentRow != null)
            {
                int taskId = (int)maintenanceTasksDataGridView.CurrentRow.Cells["task_id"].Value;
                var addEdit = new AddEditMaintenanceTaskForm(taskId);
                addEdit.FormClosed += (s, a) => LoadMaintenanceTasksAsync();
                addEdit.ShowDialog();
            }
        }

        private async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (maintenanceTasksDataGridView.CurrentRow != null)
            {
                int taskId = (int)maintenanceTasksDataGridView.CurrentRow.Cells["task_id"].Value;
                var task = await _context.MaintenanceTasks.FindAsync(taskId);

                if (task != null)
                {
                    if (MessageBox.Show("Удалить задачу техобслуживания?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.MaintenanceTasks.Remove(task);
                        await _context.SaveChangesAsync();
                        LoadMaintenanceTasksAsync();
                    }
                }
            }
        }

        private async void btnCompleteTask_Click(object sender, EventArgs e)
        {
            if (maintenanceTasksDataGridView.CurrentRow != null)
            {
                int taskId = (int)maintenanceTasksDataGridView.CurrentRow.Cells["task_id"].Value;
                var task = await _context.MaintenanceTasks.FindAsync(taskId);
                if (task != null)
                {
                    task.status = "Выполнено";
                    task.completed_date = DateTime.Now;
                    await _context.SaveChangesAsync();
                    LoadMaintenanceTasksAsync();
                }
            }
        }
    }
}
