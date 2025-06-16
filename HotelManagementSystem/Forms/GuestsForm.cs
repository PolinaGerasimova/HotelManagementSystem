using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;
using HotelManagementSystem.Forms;

namespace HotelManagementSystem
{
    public partial class GuestsForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();

        public GuestsForm()
        {
            InitializeComponent();
            LoadGuestsAsync();
        }

        private async void LoadGuestsAsync()
        {
            try
            {
                var guests = await _context.Guests.AsNoTracking().ToListAsync();

                var guestList = guests.Select(guest => new
                {
                    guest.guest_id,
                    full_name = $"{guest.last_name} {guest.first_name}" + (string.IsNullOrEmpty(guest.middle_name) ? "" : $" {guest.middle_name}"),
                    guest.phone_number,
                    guest.email,
                    registration_date = guest.registration_date.ToShortDateString()
                }).ToList();

                guestsDataGridView.DataSource = guestList;
                guestsDataGridView.Columns["guest_id"].Visible = false;

                guestsDataGridView.Columns["full_name"].HeaderText = "ФИО";
                guestsDataGridView.Columns["phone_number"].HeaderText = "Телефон";
                guestsDataGridView.Columns["email"].HeaderText = "Электронная почта";
                guestsDataGridView.Columns["registration_date"].HeaderText = "Дата регистрации";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditGuestForm();
            addEdit.GuestSaved += (s, a) => LoadGuestsAsync();
            addEdit.ShowDialog();
        }
        private void btnEditGuest_Click(object sender, EventArgs e)
        {
            if (guestsDataGridView.CurrentRow != null)
            {
                int guestId = (int)guestsDataGridView.CurrentRow.Cells["guest_id"].Value;
                var addEdit = new AddEditGuestForm(guestId);
                var result = addEdit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadGuestsAsync();
                }
            }
        }



        private async void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (guestsDataGridView.CurrentRow != null)
            {
                int guestId = (int)guestsDataGridView.CurrentRow.Cells["guest_id"].Value;
                var guest = await _context.Guests.FindAsync(guestId);

                if (guest != null)
                {
                    bool hasActiveBooking = await _context.Bookings.AnyAsync(b => b.guest_id == guestId && b.status == "Confirmed");

                    if (hasActiveBooking)
                    {
                        MessageBox.Show("Нельзя удалить гостя с активными бронированиями или проживанием!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show("Вы уверены, что хотите удалить этого гостя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _context.Guests.Remove(guest);
                        await _context.SaveChangesAsync();
                        LoadGuestsAsync();
                    }
                }
            }
        }
    }
}