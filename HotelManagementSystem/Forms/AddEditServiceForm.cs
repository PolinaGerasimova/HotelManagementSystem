using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class AddEditServiceForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();
        private readonly int? _serviceId;
        public event EventHandler ServiceSaved;

        public AddEditServiceForm(int? serviceId = null)
        {
            InitializeComponent();
            _serviceId = serviceId;

            this.Load += AddEditServiceForm_Load;
        }

        private async void AddEditServiceForm_Load(object sender, EventArgs e)
        {
            if (_serviceId.HasValue)
            {
                await LoadServiceAsync(_serviceId.Value); 
            }
        }

        private async Task LoadServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return;

            txtServiceName.Text = service.service_name;
            numericPrice.Value = service.price;
            txtDescription.Text = service.description;
            chkIsActive.Checked = service.is_active;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Введите название услуги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_serviceId.HasValue)
                {
                    var service = await _context.Services.FindAsync(_serviceId.Value);
                    if (service == null) return;

                    service.service_name = txtServiceName.Text.Trim();
                    service.price = numericPrice.Value;
                    service.description = txtDescription.Text.Trim();
                    service.is_active = chkIsActive.Checked;
                }
                else
                {
                    var service = new Service
                    {
                        service_name = txtServiceName.Text.Trim(),
                        price = numericPrice.Value,
                        description = txtDescription.Text.Trim(),
                        is_active = chkIsActive.Checked
                    };
                    _context.Services.Add(service);
                }

                await _context.SaveChangesAsync();
                ServiceSaved?.Invoke(this, EventArgs.Empty);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}

