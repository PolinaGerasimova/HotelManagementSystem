using HotelManagementSystem.Models;
using HotelManagementSystem.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Forms
{
    public partial class RoomsForm : Form
    {
        public RoomsForm()
        {
            InitializeComponent();
            LoadRoomsAsync();
        }

        private async void LoadRoomsAsync()
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var rooms = await context.Rooms
                        .Include(r => r.category)
                        .ToListAsync();

                    var roomList = rooms.Select(room => new
                    {
                        room.room_id,
                        room.room_number,
                        Category = room.category?.CategoryName ?? "Не указана",
                        room.max_occupancy,
                        room.base_price_per_night,
                        Status = room.status,
                        room.description
                    }).ToList();

                    roomsDataGridView.DataSource = roomList;
                    roomsDataGridView.Columns["room_id"].Visible = false;
                    roomsDataGridView.Columns["room_number"].HeaderText = "Номер комнаты";
                    roomsDataGridView.Columns["Category"].HeaderText = "Категория";
                    roomsDataGridView.Columns["max_occupancy"].HeaderText = "Макс. количество гостей";
                    roomsDataGridView.Columns["base_price_per_night"].HeaderText = "Цена за ночь";
                    roomsDataGridView.Columns["Status"].HeaderText = "Статус";
                    roomsDataGridView.Columns["description"].HeaderText = "Описание";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке комнат: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditRoomForm();
            addEdit.FormClosed += (s, a) => LoadRoomsAsync();
            addEdit.ShowDialog();
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (roomsDataGridView.CurrentRow != null)
            {
                int roomId = (int)roomsDataGridView.CurrentRow.Cells["room_id"].Value;
                var addEdit = new AddEditRoomForm(roomId);
                var result = addEdit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadRoomsAsync();
                }
            }
        }

        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (roomsDataGridView.CurrentRow != null)
            {
                var cellValue = roomsDataGridView.CurrentRow.Cells["room_id"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int room_id))
                {
                    using (var context = DbContextFactory.CreateContext())
                    {
                        var room = await context.Rooms.FindAsync(room_id);
                        if (room != null)
                        {
                            if (MessageBox.Show($"Удалить номер {room.room_number}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                context.Rooms.Remove(room);
                                await context.SaveChangesAsync();
                                LoadRoomsAsync();
                            }
                        }
                    }
                }
            }
        }
    }
}