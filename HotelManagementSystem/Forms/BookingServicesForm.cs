using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;
using HotelManagementSystem.Models;
using System.Data;

namespace HotelManagementSystem.Forms
{
    public partial class BookingServicesForm : Form
    {
        private readonly int _bookingId;

        public BookingServicesForm(int bookingId)
        {
            InitializeComponent();
            _bookingId = bookingId;
            LoadServicesAsync();
        }

        private async void LoadServicesAsync()
        {
            try
            {
                using (var context = DbContextFactory.CreateContext())
                {
                    var services = await context.BookingServices
                        .Where(bs => bs.booking_id == _bookingId)
                        .Include(bs => bs.service)
                        .ToListAsync();

                    var table = new DataTable();
                    table.Columns.Add("booking_service_id", typeof(int));
                    table.Columns.Add("Услуга", typeof(string));
                    table.Columns.Add("Количество", typeof(int));
                    table.Columns.Add("Цена за ед.", typeof(decimal));
                    table.Columns.Add("Общая стоимость", typeof(decimal));

                    foreach (var item in services)
                    {
                        table.Rows.Add(
                            item.booking_service_id,
                            item.service?.service_name ?? "Не указана",
                            item.quantity,
                            item.service?.price ?? 0,
                            item.total_price
                        );
                    }

                    servicesDataGridView.DataSource = table;
                    if (servicesDataGridView.Columns.Contains("booking_service_id"))
                        servicesDataGridView.Columns["booking_service_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки услуг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditBookingServiceForm(_bookingId);
            addEdit.FormClosed += (s, a) => LoadServicesAsync();
            addEdit.ShowDialog();
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (servicesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите услугу для редактирования", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int serviceId = (int)servicesDataGridView.CurrentRow.Cells["booking_service_id"].Value;
            var addEdit = new AddEditBookingServiceForm(_bookingId, serviceId);
            addEdit.FormClosed += (s, a) => LoadServicesAsync();
            addEdit.ShowDialog();
        }

        private async void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (servicesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите услугу для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int serviceId = (int)servicesDataGridView.CurrentRow.Cells["booking_service_id"].Value;
            var result = MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = DbContextFactory.CreateContext())
                    {
                        var item = await context.BookingServices.FindAsync(serviceId);
                        if (item != null)
                        {
                            context.BookingServices.Remove(item);
                            await context.SaveChangesAsync();
                            LoadServicesAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления услуги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}