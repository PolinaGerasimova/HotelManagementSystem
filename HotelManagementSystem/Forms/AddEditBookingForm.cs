using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class AddEditBookingForm : Form
    {
        private readonly int? _bookingId;
        private Room selectedRoom = null;

        public AddEditBookingForm(int? bookingId = null)
        {
            InitializeComponent();
            _bookingId = bookingId;

            LoadGuestsAsync();
            LoadRoomsAsync();
            LoadTariffsAsync();
            LoadStatuses();

            checkInDateTimePicker.Value = DateTime.Now.Date;
            checkOutDateTimePicker.Value = DateTime.Now.AddDays(1).Date;

            // Подписываемся на события изменения дат
            checkInDateTimePicker.ValueChanged += OnDateChanged;
            checkOutDateTimePicker.ValueChanged += OnDateChanged;
            tariffComboBox.SelectedValueChanged += OnTariffOrRoomChanged;
            roomComboBox.SelectedValueChanged += OnTariffOrRoomChanged;

            if (_bookingId.HasValue)
                LoadBookingDataAsync(_bookingId.Value);
        }

        private async Task<decimal> GetServicesTotalAsync(int bookingId)
        {
            using var context = DbContextFactory.CreateContext();
            return await context.BookingServices
                .Where(bs => bs.booking_id == bookingId)
                .SumAsync(bs => bs.total_price);
        }
        private void LoadStatuses()
        {
            statusComboBox.Items.Clear();
            statusComboBox.Items.AddRange(new[]
            {
                "Новое", "Подтверждено", "Зарегистрирован", "Выезд", "Отменено"
            });
        }

        private async void LoadGuestsAsync()
        {
            using (var context = DbContextFactory.CreateContext())
            {
                var guests = await context.Guests.OrderBy(g => g.last_name).ToListAsync();
                guestComboBox.DataSource = guests;
                guestComboBox.DisplayMember = "last_name";
                guestComboBox.ValueMember = "guest_id";
            }
        }

        private async void LoadRoomsAsync()
        {
            using (var context = DbContextFactory.CreateContext())
            {
                var rooms = await context.Rooms
                    .Include(r => r.category)
                    .Where(r => r.status == "Доступен" || (!_bookingId.HasValue && r.status != "Неисправен"))
                    .OrderBy(r => r.room_number)
                    .ToListAsync();

                roomComboBox.DataSource = rooms;
                roomComboBox.DisplayMember = "room_number";
                roomComboBox.ValueMember = "room_id";
            }
        }

        private async void LoadTariffsAsync()
        {
            using (var context = DbContextFactory.CreateContext())
            {
                var tariffs = await context.Tariffs.Where(t => t.is_active).OrderBy(t => t.tariff_name).ToListAsync();
                tariffs.Insert(0, new Tariff { tariff_id = 0, tariff_name = "Без тарифа" });

                tariffComboBox.DataSource = tariffs;
                tariffComboBox.DisplayMember = "tariff_name";
                tariffComboBox.ValueMember = "tariff_id";
                tariffComboBox.SelectedIndex = 0;
            }
        }

        private async Task LoadBookingDataAsync(int bookingId)
        {
            using (var context = DbContextFactory.CreateContext())
            {
                var booking = await context.Bookings
                    .Include(b => b.guest)
                    .Include(b => b.room)
                    .Include(b => b.tariff)
                    .FirstOrDefaultAsync(b => b.booking_id == bookingId);

                if (booking != null)
                {
                    guestComboBox.SelectedValue = booking.guest_id;
                    roomComboBox.SelectedValue = booking.room_id;
                    selectedRoom = booking.room;

                    if (booking.tariff_id.HasValue && booking.tariff_id.Value != 0)
                        tariffComboBox.SelectedValue = booking.tariff_id.Value;
                    else
                        tariffComboBox.SelectedIndex = 0;

                    checkInDateTimePicker.Value = booking.check_in_date;
                    checkOutDateTimePicker.Value = booking.check_out_date;
                    numberOfGuestsNumeric.Value = booking.number_of_guests;
                    notesTextBox.Text = booking.notes ?? string.Empty;
                    statusComboBox.SelectedItem = booking.status;

                    UpdateTotalCost();
                }
            }
        }

        private void OnDateChanged(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        private void OnTariffOrRoomChanged(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        private void UpdateTotalCost()
        {
            if (roomComboBox.SelectedItem is Room room)
            {
                selectedRoom = room;

                decimal pricePerNight = room.base_price_per_night;
                int days = (int)(checkOutDateTimePicker.Value.Date - checkInDateTimePicker.Value.Date).TotalDays;
                if (days <= 0) days = 1;

                decimal totalPrice = pricePerNight * days;

                if (tariffComboBox.SelectedItem is Tariff tariff && tariff.tariff_id != 0)
                {
                    totalPrice -= totalPrice * tariff.discount_percentage / 100;
                }

                totalCostLabel.Text = $"Общая стоимость: {totalPrice:N2} ₽";
            }
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            if (guestComboBox.SelectedItem == null || roomComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите гостя и номер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkOutDateTimePicker.Value <= checkInDateTimePicker.Value)
            {
                MessageBox.Show("Дата выезда должна быть позже даты заезда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    Room room = await context.Rooms.FindAsync((int)roomComboBox.SelectedValue);
                    if (room == null)
                    {
                        MessageBox.Show("Выбранный номер не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Тариф, если выбраны услуги
                    Tariff tariff = null;
                    if (tariffComboBox.SelectedIndex > 0)
                    {
                        tariff = await context.Tariffs.FindAsync((int)tariffComboBox.SelectedValue);
                    }

                    if (_bookingId.HasValue)
                    {
                        var booking = await context.Bookings.FindAsync(_bookingId.Value);
                        booking.guest_id = (int)guestComboBox.SelectedValue;
                        booking.room_id = (int)roomComboBox.SelectedValue;
                        booking.tariff_id = (tariffComboBox.SelectedIndex > 0) ? (int?)tariffComboBox.SelectedValue : null;
                        booking.check_in_date = checkInDateTimePicker.Value.Date;
                        booking.check_out_date = checkOutDateTimePicker.Value.Date;
                        booking.number_of_guests = (int)numberOfGuestsNumeric.Value;
                        booking.notes = string.IsNullOrWhiteSpace(notesTextBox.Text) ? null : notesTextBox.Text;
                        booking.status = statusComboBox.SelectedItem?.ToString() ?? "Новое";

                        // Пересчитываем стоимость с загруженным тарифом
                        booking.total_cost = CalculateTotalCost(room, booking.check_in_date, booking.check_out_date, tariff);
                        booking.total_summ = booking.total_cost + await GetServicesTotalAsync(booking.booking_id);
                    }
                    else
                    {
                        var booking = new Booking
                        {
                            guest_id = (int)guestComboBox.SelectedValue,
                            room_id = (int)roomComboBox.SelectedValue,
                            tariff_id = (tariffComboBox.SelectedIndex > 0) ? (int?)tariffComboBox.SelectedValue : null,
                            check_in_date = checkInDateTimePicker.Value.Date,
                            check_out_date = checkOutDateTimePicker.Value.Date,
                            number_of_guests = (int)numberOfGuestsNumeric.Value,
                            status = statusComboBox.SelectedItem?.ToString() ?? "Новое",
                            booking_date = DateTime.Now,
                            notes = string.IsNullOrWhiteSpace(notesTextBox.Text) ? null : notesTextBox.Text
                        };

                        // Считаем стоимость с загруженным тарифом
                        booking.total_cost = CalculateTotalCost(room, booking.check_in_date, booking.check_out_date, tariff);
                        context.Bookings.Add(booking);
                        await context.SaveChangesAsync(); 

                        // Теперь рассчитываем total_summ с учетом услуг
                        booking.total_summ = booking.total_cost + await GetServicesTotalAsync(booking.booking_id);
                        context.Entry(booking).State = EntityState.Modified;
                    }

                    await context.SaveChangesAsync();
                    MessageBox.Show("Бронирование сохранено успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateTotalCost(Room room, DateTime checkIn, DateTime checkOut, Tariff tariff)
        {
            int days = (int)(checkOut.Date - checkIn.Date).TotalDays;
            if (days <= 0) days = 1;

            decimal totalPrice = room.base_price_per_night * days;

            if (tariff != null && tariff.tariff_id != 0)
            {
                decimal discountPercent = tariff.discount_percentage;
                totalPrice -= totalPrice * discountPercent / 100;
            }

            return totalPrice;
        }
    }
}