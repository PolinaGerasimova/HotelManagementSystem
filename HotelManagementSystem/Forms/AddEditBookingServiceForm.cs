using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Forms
{
    public partial class AddEditBookingServiceForm : Form
    {
        private readonly int _bookingId;
        private readonly int? _serviceId;

        public AddEditBookingServiceForm(int bookingId, int? serviceId = null)
        {
            InitializeComponent();
            _bookingId = bookingId;
            _serviceId = serviceId;

            LoadServicesAsync();

            if (_serviceId.HasValue)
                LoadServiceDataAsync(_serviceId.Value);
        }

        private async void LoadServicesAsync()
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var services = await context.Services
                        .Where(s => s.is_active)
                        .OrderBy(s => s.service_name)
                        .ToListAsync();

                    serviceComboBox.DataSource = services;
                    serviceComboBox.DisplayMember = "service_name";
                    serviceComboBox.ValueMember = "service_id";

                    if (services.Count > 0)
                        serviceComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки услуг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadServiceDataAsync(int serviceId)
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var item = await context.BookingServices
                        .Include(bs => bs.service)
                        .FirstOrDefaultAsync(bs => bs.booking_service_id == serviceId);

                    if (item != null)
                    {
                        serviceComboBox.SelectedValue = item.service_id;
                        numericQuantity.Value = item.quantity;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных услуги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (serviceComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericQuantity.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    BookingServiceItem item;

                    if (_serviceId.HasValue)
                    {
                        item = await context.BookingServices
                            .FirstOrDefaultAsync(bs => bs.booking_service_id == _serviceId.Value);

                        if (item == null)
                        {
                            MessageBox.Show("Запись не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        item = new BookingServiceItem
                        {
                            booking_id = _bookingId
                        };
                        context.BookingServices.Add(item);
                    }

                    item.service_id = (int)serviceComboBox.SelectedValue;
                    item.quantity = (int)numericQuantity.Value;

                    var service = await context.Services.FindAsync(item.service_id);
                    if (service == null)
                    {
                        MessageBox.Show("Выбранная услуга не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    item.total_price = service.price * item.quantity;

                    await context.SaveChangesAsync();
                    await UpdateBookingTotalSum();

                    MessageBox.Show("Услуга сохранена успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateBookingTotalSum()
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var booking = await context.Bookings.FindAsync(_bookingId);
                    if (booking != null)
                    {
                        var servicesTotal = await context.BookingServices
                            .Where(bs => bs.booking_id == _bookingId)
                            .SumAsync(bs => bs.total_price);

                        booking.total_summ = booking.total_cost + servicesTotal;
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления total_summ: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}