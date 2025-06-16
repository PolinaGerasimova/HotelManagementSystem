namespace HotelManagementSystem
{
    partial class AddEditEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmploymentDate;
        private System.Windows.Forms.DateTimePicker dtpEmploymentDate;
        private System.Windows.Forms.Label lblWorkSchedule;
        private System.Windows.Forms.TextBox txtWorkSchedule;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblRole = new Label();
            txtRole = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmploymentDate = new Label();
            dtpEmploymentDate = new DateTimePicker();
            lblWorkSchedule = new Label();
            txtWorkSchedule = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F);
            lblFirstName.Location = new Point(20, 15);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(39, 20);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "Имя";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 9F);
            txtFirstName.Location = new Point(20, 35);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(300, 27);
            txtFirstName.TabIndex = 1;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F);
            lblLastName.Location = new Point(350, 15);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(73, 20);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Фамилия";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 9F);
            txtLastName.Location = new Point(350, 35);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(300, 27);
            txtLastName.TabIndex = 3;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 9F);
            lblMiddleName.Location = new Point(20, 70);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(72, 20);
            lblMiddleName.TabIndex = 4;
            lblMiddleName.Text = "Отчество";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Segoe UI", 9F);
            txtMiddleName.Location = new Point(20, 90);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(300, 27);
            txtMiddleName.TabIndex = 5;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.Location = new Point(350, 70);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(86, 20);
            lblRole.TabIndex = 6;
            lblRole.Text = "Должность";
            // 
            // txtRole
            // 
            txtRole.Font = new Font("Segoe UI", 9F);
            txtRole.Location = new Point(350, 90);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(300, 27);
            txtRole.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.Location = new Point(20, 125);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(69, 20);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9F);
            txtPhone.Location = new Point(20, 145);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(300, 27);
            txtPhone.TabIndex = 9;
            // 
            // lblEmploymentDate
            // 
            lblEmploymentDate.AutoSize = true;
            lblEmploymentDate.Font = new Font("Segoe UI", 9F);
            lblEmploymentDate.Location = new Point(350, 125);
            lblEmploymentDate.Name = "lblEmploymentDate";
            lblEmploymentDate.Size = new Size(99, 20);
            lblEmploymentDate.TabIndex = 10;
            lblEmploymentDate.Text = "Дата приема";
            // 
            // dtpEmploymentDate
            // 
            dtpEmploymentDate.Font = new Font("Segoe UI", 9F);
            dtpEmploymentDate.Format = DateTimePickerFormat.Short;
            dtpEmploymentDate.Location = new Point(350, 145);
            dtpEmploymentDate.Name = "dtpEmploymentDate";
            dtpEmploymentDate.Size = new Size(300, 27);
            dtpEmploymentDate.TabIndex = 11;
            // 
            // lblWorkSchedule
            // 
            lblWorkSchedule.AutoSize = true;
            lblWorkSchedule.Font = new Font("Segoe UI", 9F);
            lblWorkSchedule.Location = new Point(20, 180);
            lblWorkSchedule.Name = "lblWorkSchedule";
            lblWorkSchedule.Size = new Size(115, 20);
            lblWorkSchedule.TabIndex = 12;
            lblWorkSchedule.Text = "График работы";
            // 
            // txtWorkSchedule
            // 
            txtWorkSchedule.Font = new Font("Segoe UI", 9F);
            txtWorkSchedule.Location = new Point(20, 200);
            txtWorkSchedule.Multiline = true;
            txtWorkSchedule.Name = "txtWorkSchedule";
            txtWorkSchedule.Size = new Size(630, 50);
            txtWorkSchedule.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(434, 273);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 14;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(551, 273);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            // 
            // AddEditEmployeeForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(680, 320);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblRole);
            Controls.Add(txtRole);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblEmploymentDate);
            Controls.Add(dtpEmploymentDate);
            Controls.Add(lblWorkSchedule);
            Controls.Add(txtWorkSchedule);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditEmployeeForm";
            Text = "Сотрудник";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
