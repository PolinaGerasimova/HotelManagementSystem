using HotelManagementSystem.Models;
using HotelManagementSystem.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class AddEditGuestForm : Form
    {
        private readonly HotelManagementContext _context = DbContextFactory.CreateContext();
        private readonly int? _guestId;
        public event EventHandler GuestSaved;

        public AddEditGuestForm(int? guestId = null)
        {
            InitializeComponent();
            _guestId = guestId;
            if (_guestId.HasValue)
            {
                _ = LoadGuestAsync(_guestId.Value);
            }
            else
            {
                dateBirth.Value = DateTime.Today;
            }
        }

        private async Task LoadGuestAsync(int guestId)
        {
            var guest = await _context.Guests.FindAsync(guestId);
            if (guest == null) return;

            txtFirstName.Text = guest.first_name;
            txtLastName.Text = guest.last_name;
            txtMiddleName.Text = guest.middle_name;
            txtPhone.Text = guest.phone_number;
            txtEmail.Text = guest.email;
            txtPassport.Text = guest.passport_number;
            txtAddress.Text = guest.address;
            dateBirth.Value = guest.date_of_birth ?? DateTime.Today;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Поля Имя, Фамилия и Телефон обязательны для заполнения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = CalculateAge(dateBirth.Value, DateTime.Today);
            if (age < 18)
            {
                MessageBox.Show("Возраст не может быть младше 18 лет.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await SaveGuestAsync();
        }

        private async Task SaveGuestAsync()
        {
            try
            {
                if (_guestId.HasValue)
                {
                    var guest = await _context.Guests.FindAsync(_guestId.Value);
                    if (guest == null) return;

                    guest.first_name = txtFirstName.Text.Trim();
                    guest.last_name = txtLastName.Text.Trim();
                    guest.middle_name = txtMiddleName.Text.Trim();
                    guest.phone_number = txtPhone.Text.Trim();
                    guest.email = txtEmail.Text.Trim();
                    guest.passport_number = txtPassport.Text.Trim();
                    guest.address = txtAddress.Text.Trim();
                    guest.date_of_birth = dateBirth.Value;
                }
                else
                {
                    var guest = new Guest
                    {
                        first_name = txtFirstName.Text.Trim(),
                        last_name = txtLastName.Text.Trim(),
                        middle_name = txtMiddleName.Text.Trim(),
                        phone_number = txtPhone.Text.Trim(),
                        email = txtEmail.Text.Trim(),
                        passport_number = txtPassport.Text.Trim(),
                        address = txtAddress.Text.Trim(),
                        date_of_birth = dateBirth.Value,
                        registration_date = DateTime.Today
                    };
                    _context.Guests.Add(guest);
                }
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                GuestSaved?.Invoke(this, EventArgs.Empty);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении гостя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CalculateAge(DateTime birthDate, DateTime currentDate)
        {
            int age = currentDate.Year - birthDate.Year;
            if (currentDate.Month < birthDate.Month ||
               (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
    }
}

