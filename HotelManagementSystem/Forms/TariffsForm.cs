using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Services;

namespace HotelManagementSystem
{
    public partial class TariffsForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();

        public TariffsForm()
        {
            InitializeComponent();
            LoadTariffsAsync();
        }

        private async void LoadTariffsAsync()
        {
            var tariffs = await _context.Tariffs.AsNoTracking().ToListAsync();
            tariffsDataGridView.DataSource = tariffs.Select(t => new
            {
                t.tariff_id,
                t.tariff_name,
                t.discount_percentage,
                t.description,
                is_active = t.is_active ? "Активен" : "Неактивен"
            }).ToList();

            if (tariffsDataGridView.Columns["tariff_id"] != null)
                tariffsDataGridView.Columns["tariff_id"].Visible = false;

            tariffsDataGridView.Columns["tariff_name"].HeaderText = "Название тарифа";
            tariffsDataGridView.Columns["discount_percentage"].HeaderText = "Процент скидки";
            tariffsDataGridView.Columns["description"].HeaderText = "Описание";
            tariffsDataGridView.Columns["is_active"].HeaderText = "Статус";
        }

        private void btnAddTariff_Click(object sender, EventArgs e)
        {
            var addEdit = new AddEditTariffForm();
            addEdit.FormClosed += (s, a) => LoadTariffsAsync();
            addEdit.ShowDialog();
        }

        private void btnEditTariff_Click(object sender, EventArgs e)
        {
            if (tariffsDataGridView.CurrentRow != null)
            {
                int tariffId = (int)tariffsDataGridView.CurrentRow.Cells["tariff_id"].Value;
                var addEdit = new AddEditTariffForm(tariffId);
                addEdit.FormClosed += (s, a) => LoadTariffsAsync();
                addEdit.ShowDialog();
            }
        }

        private async void btnDeleteTariff_Click(object sender, EventArgs e)
        {
            if (tariffsDataGridView.CurrentRow != null)
            {
                int tariffId = (int)tariffsDataGridView.CurrentRow.Cells["tariff_id"].Value;
                var tariff = await _context.Tariffs.FindAsync(tariffId);

                if (tariff != null)
                {
                    if (MessageBox.Show("Удалить тариф?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.Tariffs.Remove(tariff);
                        await _context.SaveChangesAsync();
                        LoadTariffsAsync();
                    }
                }
            }
        }
    }
}
