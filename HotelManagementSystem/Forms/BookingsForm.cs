using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;
using HotelManagementSystem.Models;
using HotelManagementSystem.Forms;

namespace HotelManagementSystem
{
    public partial class BookingsForm : Form
    {
        public BookingsForm()
        {
            InitializeComponent();
            LoadBookingsAsync();
        }

        private async void LoadBookingsAsync()
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var bookings = await context.Bookings
                        .Include(b => b.guest)
                        .Include(b => b.room)
                        .Include(b => b.tariff)
                        .ToListAsync();

                    var table = new System.Data.DataTable();

                    table.Columns.Add("booking_id", typeof(int));
                    table.Columns.Add("Гость", typeof(string));
                    table.Columns.Add("Номер комнаты", typeof(string));
                    table.Columns.Add("Тариф", typeof(string));
                    table.Columns.Add("Дата заезда", typeof(string));
                    table.Columns.Add("Дата выезда", typeof(string));
                    table.Columns.Add("Количество гостей", typeof(int));
                    table.Columns.Add("Стоимость без услуг", typeof(string));
                    table.Columns.Add("Итого к оплате", typeof(string)); 
                    table.Columns.Add("Статус", typeof(string));
                    table.Columns.Add("Дата бронирования", typeof(string));
                    table.Columns.Add("Примечания", typeof(string));

                    foreach (var b in bookings)
                    {
                        var servicesTotal = await context.BookingServices
                            .Where(bs => bs.booking_id == b.booking_id)
                            .SumAsync(bs => bs.total_price);

                        var notes = b.notes;
                        table.Rows.Add(
                            b.booking_id,
                            $"{b.guest.last_name} {b.guest.first_name} {(string.IsNullOrEmpty(b.guest.middle_name) ? "" : b.guest.middle_name)}",
                            b.room.room_number,
                            b.tariff?.tariff_name ?? "Не указан",
                            b.check_in_date.ToShortDateString(),
                            b.check_out_date.ToShortDateString(),
                            b.number_of_guests,
                            b.total_cost.ToString("N2"),
                            (b.total_cost + servicesTotal).ToString("N2"),
                            b.status ?? string.Empty,
                            b.booking_date.ToShortDateString(),
                            notes == null || notes is DBNull ? string.Empty : notes
                        );
                    }
                    bookingsDataGridView.DataSource = table;

                    if (bookingsDataGridView.Columns["booking_id"] != null)
                        bookingsDataGridView.Columns["booking_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string SafeToString(object value)
        {
            return value == null || Convert.IsDBNull(value) ? null : value.ToString();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditBookingForm();
            addEdit.FormClosed += (s, a) => LoadBookingsAsync();
            addEdit.ShowDialog();
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            if (bookingsDataGridView.CurrentRow != null)
            {
                int bookingId = (int)bookingsDataGridView.CurrentRow.Cells["booking_id"].Value;
                var addEdit = new AddEditBookingForm(bookingId);
                addEdit.FormClosed += (s, a) => LoadBookingsAsync();
                addEdit.ShowDialog();
            }
        }

        private async void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (bookingsDataGridView.CurrentRow != null)
            {
                int bookingId = (int)bookingsDataGridView.CurrentRow.Cells["booking_id"].Value;
                using (var context = DbContextFactory.CreateContext())
                {
                    var booking = await context.Bookings.FindAsync(bookingId);

                    if (booking != null)
                    {
                        if (booking.status == "Зарегистрирован")
                        {
                            MessageBox.Show("Нельзя отменить бронирование после заселения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (MessageBox.Show("Отменить бронирование?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            booking.status = "Отменено";
                            var room = await context.Rooms.FindAsync(booking.room_id);
                            if (room != null && room.status == "Занят")
                                room.status = "Доступен";

                            await context.SaveChangesAsync();
                            LoadBookingsAsync();
                        }
                    }
                }
            }
        }

        private void btnBookingService_Click(object sender, EventArgs e)
        {
            if (bookingsDataGridView.CurrentRow != null)
            {
                int bookingId = (int)bookingsDataGridView.CurrentRow.Cells["booking_id"].Value;

                var form = new BookingServicesForm(bookingId);
                form.FormClosed += (s, args) => LoadBookingsAsync(); 
                form.Show();
            }
            else
            {
                MessageBox.Show("Выберите бронирование", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
