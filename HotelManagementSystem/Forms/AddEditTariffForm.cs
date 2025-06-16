using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class AddEditTariffForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();
        private readonly int? _tariffId;
        public event EventHandler TariffSaved;

        public AddEditTariffForm(int? tariffId = null)
        {
            InitializeComponent();
            _tariffId = tariffId;

            this.Load += AddEditTariffForm_Load;
        }

        private async void AddEditTariffForm_Load(object sender, EventArgs e)
        {
            if (_tariffId.HasValue)
            {
                await LoadTariffAsync(_tariffId.Value);
            }
        }

        private async Task LoadTariffAsync(int tariffId)
        {
            var tariff = await _context.Tariffs.FindAsync(tariffId);
            if (tariff == null)
            {
                MessageBox.Show($"Тариф с ID {tariffId} не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtTariffName.Text = tariff.tariff_name;
            numericDiscount.Value = tariff.discount_percentage;
            txtDescription.Text = tariff.description;
            chkIsActive.Checked = tariff.is_active;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTariffName.Text))
            {
                MessageBox.Show("Пожалуйста, введите название тарифа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_tariffId.HasValue)
                {
                    var tariff = await _context.Tariffs.FindAsync(_tariffId.Value);
                    if (tariff == null) return;

                    tariff.tariff_name = txtTariffName.Text.Trim();
                    tariff.discount_percentage = numericDiscount.Value;
                    tariff.description = txtDescription.Text.Trim();
                    tariff.is_active = chkIsActive.Checked;
                }
                else
                {
                    var tariff = new Tariff
                    {
                        tariff_name = txtTariffName.Text.Trim(),
                        discount_percentage = numericDiscount.Value,
                        description = txtDescription.Text.Trim(),
                        is_active = chkIsActive.Checked
                    };
                    _context.Tariffs.Add(tariff);
                }

                await _context.SaveChangesAsync();

                TariffSaved?.Invoke(this, EventArgs.Empty);

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
