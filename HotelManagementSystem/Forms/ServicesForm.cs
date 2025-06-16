using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class ServicesForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();

        public ServicesForm()
        {
            InitializeComponent();
            LoadServicesAsync();
        }

        private async void LoadServicesAsync()
        {
            var services = await _context.Services.AsNoTracking().ToListAsync();
            servicesDataGridView.DataSource = services.Select(s => new
            {
                s.service_id,
                s.service_name,
                s.price,
                s.description,
                is_active = s.is_active ? "Активна" : "Неактивна"
            }).ToList();

            if (servicesDataGridView.Columns["service_id"] != null)
                servicesDataGridView.Columns["service_id"].Visible = false;

            servicesDataGridView.Columns["service_name"].HeaderText = "Название услуги";
            servicesDataGridView.Columns["price"].HeaderText = "Цена";
            servicesDataGridView.Columns["description"].HeaderText = "Описание";
            servicesDataGridView.Columns["is_active"].HeaderText = "Статус";
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditServiceForm();
            addEdit.FormClosed += (s, a) => LoadServicesAsync();
            addEdit.ShowDialog();
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (servicesDataGridView.CurrentRow != null)
            {
                int serviceId = (int)servicesDataGridView.CurrentRow.Cells["service_id"].Value;
                var addEdit = new AddEditServiceForm(serviceId);
                addEdit.FormClosed += (s, a) => LoadServicesAsync();
                addEdit.ShowDialog();
            }
        }

        private async void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (servicesDataGridView.CurrentRow != null)
            {
                int serviceId = (int)servicesDataGridView.CurrentRow.Cells["service_id"].Value;
                var service = await _context.Services.FindAsync(serviceId);

                if (service != null)
                {
                    if (MessageBox.Show("Удалить услугу?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.Services.Remove(service);
                        await _context.SaveChangesAsync();
                        LoadServicesAsync();
                    }
                }
            }
        }
    }
}


