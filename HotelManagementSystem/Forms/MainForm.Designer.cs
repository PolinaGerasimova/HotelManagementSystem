namespace HotelManagementSystem.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnGuests = new Button();
            btnRooms = new Button();
            btnBookings = new Button();
            btnCleaning = new Button();
            btnMaintenance = new Button();
            btnEmployees = new Button();
            btnServices = new Button();
            btnTariffs = new Button();
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            btnPasswordHashGenerator = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGuests
            // 
            btnGuests.Location = new Point(18, 31);
            btnGuests.Name = "btnGuests";
            btnGuests.Size = new Size(150, 50);
            btnGuests.TabIndex = 0;
            btnGuests.Text = "Управление Гостями";
            btnGuests.UseVisualStyleBackColor = true;
            btnGuests.Click += btnGuests_Click;
            // 
            // btnRooms
            // 
            btnRooms.Location = new Point(198, 31);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(150, 50);
            btnRooms.TabIndex = 1;
            btnRooms.Text = "Управление Номерами";
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnBookings
            // 
            btnBookings.Location = new Point(18, 101);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(150, 50);
            btnBookings.TabIndex = 2;
            btnBookings.Text = "Управление Бронирован.";
            btnBookings.UseVisualStyleBackColor = true;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnCleaning
            // 
            btnCleaning.Location = new Point(18, 241);
            btnCleaning.Name = "btnCleaning";
            btnCleaning.Size = new Size(150, 50);
            btnCleaning.TabIndex = 3;
            btnCleaning.Text = "Задачи Уборки";
            btnCleaning.UseVisualStyleBackColor = true;
            btnCleaning.Click += btnCleaning_Click;
            // 
            // btnMaintenance
            // 
            btnMaintenance.Location = new Point(198, 241);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Size = new Size(150, 50);
            btnMaintenance.TabIndex = 4;
            btnMaintenance.Text = "Задачи Техобслуживания";
            btnMaintenance.UseVisualStyleBackColor = true;
            btnMaintenance.Click += btnMaintenance_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.Location = new Point(18, 171);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(150, 50);
            btnEmployees.TabIndex = 5;
            btnEmployees.Text = "Управление Сотрудниками";
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnServices
            // 
            btnServices.Location = new Point(198, 101);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(150, 50);
            btnServices.TabIndex = 6;
            btnServices.Text = "Управление Услугами";
            btnServices.UseVisualStyleBackColor = true;
            btnServices.Click += btnServices_Click;
            // 
            // btnTariffs
            // 
            btnTariffs.Location = new Point(198, 171);
            btnTariffs.Name = "btnTariffs";
            btnTariffs.Size = new Size(150, 50);
            btnTariffs.TabIndex = 7;
            btnTariffs.Text = "Управление Тарифами";
            btnTariffs.UseVisualStyleBackColor = true;
            btnTariffs.Click += btnTariffs_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(822, 442);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 50);
            btnClose.TabIndex = 9;
            btnClose.Text = "Выход";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(382, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(590, 390);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // btnPasswordHashGenerator
            // 
            btnPasswordHashGenerator.Location = new Point(18, 442);
            btnPasswordHashGenerator.Name = "btnPasswordHashGenerator";
            btnPasswordHashGenerator.Size = new Size(150, 50);
            btnPasswordHashGenerator.TabIndex = 11;
            btnPasswordHashGenerator.Text = "Новый ползователь";
            btnPasswordHashGenerator.UseVisualStyleBackColor = true;
            btnPasswordHashGenerator.Click += btnPasswordHashGenerator_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1003, 518);
            Controls.Add(btnPasswordHashGenerator);
            Controls.Add(pictureBox1);
            Controls.Add(btnClose);
            Controls.Add(btnGuests);
            Controls.Add(btnRooms);
            Controls.Add(btnBookings);
            Controls.Add(btnCleaning);
            Controls.Add(btnMaintenance);
            Controls.Add(btnEmployees);
            Controls.Add(btnServices);
            Controls.Add(btnTariffs);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Панель управления отелем";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnGuests;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnBookings;
        private System.Windows.Forms.Button btnCleaning;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnTariffs;
        private Button btnClose;
        private PictureBox pictureBox1;
        private Button btnPasswordHashGenerator;
    }
}
