using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace HotelManagementSystem
{
    public partial class CleaningTasksForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();

        public CleaningTasksForm()
        {
            InitializeComponent();
            LoadCleaningTasksAsync();

        }

        private async void LoadCleaningTasksAsync()
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var tasks = await context.CleaningTasks
                        .Include(t => t.room)
                        .Include(t => t.employee)
                        .ToListAsync();

                    var table = new System.Data.DataTable();
                    table.Columns.Add("task_id", typeof(int));
                    table.Columns.Add("Номер комнаты", typeof(string));
                    table.Columns.Add("Сотрудник", typeof(string));
                    table.Columns.Add("Тип задачи", typeof(string));
                    table.Columns.Add("Запланировано", typeof(string));
                    table.Columns.Add("Выполнено", typeof(string));
                    table.Columns.Add("Статус", typeof(string));
                    table.Columns.Add("Оценочная продолжительность", typeof(int));
                    table.Columns.Add("Примечания", typeof(string));

                    foreach (var t in tasks)
                    {
                        var notes = t.notes;
                        table.Rows.Add(
                            t.task_id,
                            t.room.room_number,
                            $"{t.employee.first_name} {t.employee.last_name}",
                            t.task_type ?? string.Empty,
                            t.scheduled_date.ToShortDateString(),
                            t.completed_date.HasValue ? t.completed_date.Value.ToShortDateString() : string.Empty,
                            t.status ?? string.Empty,
                            t.estimated_duration.HasValue ? t.estimated_duration.Value : 0,
                            notes == null || notes is DBNull ? string.Empty : notes
                        );
                    }
                    cleaningTasksDataGridView.DataSource = table;

                    if (cleaningTasksDataGridView.Columns["task_id"] != null)
                        cleaningTasksDataGridView.Columns["task_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditCleaningTaskForm();
            addEdit.FormClosed += (s, a) => LoadCleaningTasksAsync();
            addEdit.ShowDialog();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (cleaningTasksDataGridView.CurrentRow != null)
            {
                int taskId = (int)cleaningTasksDataGridView.CurrentRow.Cells["task_id"].Value;
                var addEdit = new AddEditCleaningTaskForm(taskId);
                addEdit.FormClosed += (s, a) => LoadCleaningTasksAsync();
                addEdit.ShowDialog();
            }
        }

        private async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (cleaningTasksDataGridView.CurrentRow != null)
            {
                int taskId = (int)cleaningTasksDataGridView.CurrentRow.Cells["task_id"].Value;
                var task = await _context.CleaningTasks.FindAsync(taskId);

                if (task != null)
                {
                    if (MessageBox.Show("Удалить задачу уборки?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.CleaningTasks.Remove(task);
                        await _context.SaveChangesAsync();
                        LoadCleaningTasksAsync();
                    }
                }
            }
        }

        private async void btnCompleteTask_Click(object sender, EventArgs e)
        {
            if (cleaningTasksDataGridView.CurrentRow != null)
            {
                int taskId = (int)cleaningTasksDataGridView.CurrentRow.Cells["task_id"].Value;
                var task = await _context.CleaningTasks.FindAsync(taskId);
                if (task != null)
                {
                    task.status = "Выполнено";
                    task.completed_date = DateTime.Now;
                                                       
                    await _context.SaveChangesAsync();
                    LoadCleaningTasksAsync();
                }
            }
        }
    }
}

