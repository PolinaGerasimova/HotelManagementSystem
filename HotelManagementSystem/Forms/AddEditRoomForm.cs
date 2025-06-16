using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Forms
{
    public partial class AddEditRoomForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();
        private readonly int? _roomId;

        public event EventHandler RoomSaved;

        public AddEditRoomForm(int? roomId = null)
        {
            InitializeComponent();
            _roomId = roomId;
            InitStatusComboBox();
            this.Load += AddEditRoomForm_Load;
        }

        private async void AddEditRoomForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            if (_roomId.HasValue)
                await LoadRoomAsync(_roomId.Value);
            else
                cmbStatus.SelectedItem = "Доступен";
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _context.RoomCategories.AsNoTracking().ToListAsync();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void InitStatusComboBox()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new[]
            {
                "Доступен", "Занят", "Уборка", "Техническое обслуживание", "Неисправен"
            });
        }

        private async Task LoadRoomAsync(int roomId)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.room_id == roomId);
            if (room == null)
            {
                MessageBox.Show($"Номер комнаты с ID {roomId} не найден!");
                return;
            }
            txtRoomNumber.Text = room.room_number ?? string.Empty;
            cmbCategory.SelectedValue = room.category_id;
            numMaxOccupancy.Value = room.max_occupancy;
            numBasePrice.Value = room.base_price_per_night;
            cmbStatus.SelectedItem = room.status;
            txtDescription.Text = room.description ?? string.Empty;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните номер комнаты и категорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Room room;
                if (_roomId.HasValue)
                {
                    room = await _context.Rooms.FindAsync(_roomId.Value);
                    if (room == null)
                    {
                        MessageBox.Show("Ошибка: объект комнаты не найден для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    room = new Room();
                    _context.Rooms.Add(room);
                }

                room.room_number = txtRoomNumber.Text.Trim();
                room.category_id = (int)cmbCategory.SelectedValue;
                room.max_occupancy = (int)numMaxOccupancy.Value;
                room.base_price_per_night = numBasePrice.Value;
                room.status = cmbStatus.SelectedItem?.ToString() ?? "Доступен";
                room.description = txtDescription.Text.Trim();

                await _context.SaveChangesAsync();
                RoomSaved?.Invoke(this, EventArgs.Empty);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении номера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}