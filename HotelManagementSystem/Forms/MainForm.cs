using System;
using System.Windows.Forms;
using HotelManagementSystem.Models;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly HotelManagementContext _context;

        public MainForm()
        {
            InitializeComponent();
            InitializeAdminControls();
            _context = DbContextFactory.CreateContext();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            using (var form = new RoomsForm())
            {
                form.ShowDialog();
            }
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            using (var form = new BookingsForm())
            {
                form.ShowDialog();
            }
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            using (var form = new GuestsForm())
            {
                form.ShowDialog();
            }
        }

        private void btnCleaning_Click(object sender, EventArgs e)
        {
            using (var form = new CleaningTasksForm())
            {
                form.ShowDialog();
            }
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            using (var form = new MaintenanceTasksForm())
            {
                form.ShowDialog();
            }
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeesForm())
            {
                form.ShowDialog();
            }
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            using (var form = new ServicesForm())
            {
                form.ShowDialog();
            }
        }

        private void btnTariffs_Click(object sender, EventArgs e)
        {
            using (var form = new TariffsForm())
            {
                form.ShowDialog();
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void InitializeAdminControls()
        {
            if (CurrentUser.IsAdmin)
            {
                btnPasswordHashGenerator.Visible = true;
            }
            else
            {
                btnPasswordHashGenerator.Visible = false;
            }
        }

        private void btnPasswordHashGenerator_Click(object sender, EventArgs e)
        {
            var form = new PasswordHashGeneratorForm();
            form.ShowDialog();
        }
    }
}
