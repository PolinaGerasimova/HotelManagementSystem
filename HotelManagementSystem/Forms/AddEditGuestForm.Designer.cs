namespace HotelManagementSystem
{
    partial class AddEditGuestForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDateBirth;
        private System.Windows.Forms.DateTimePicker dateBirth;
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
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassport = new Label();
            txtPassport = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblDateBirth = new Label();
            dateBirth = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F);
            lblFirstName.Location = new Point(417, 21);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(39, 20);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "Имя";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 9F);
            txtFirstName.Location = new Point(417, 43);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(365, 27);
            txtFirstName.TabIndex = 1;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F);
            lblLastName.Location = new Point(23, 21);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(73, 20);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Фамилия";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 9F);
            txtLastName.Location = new Point(23, 43);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(365, 27);
            txtLastName.TabIndex = 3;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 9F);
            lblMiddleName.Location = new Point(23, 88);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(72, 20);
            lblMiddleName.TabIndex = 4;
            lblMiddleName.Text = "Отчество";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Segoe UI", 9F);
            txtMiddleName.Location = new Point(23, 111);
            txtMiddleName.Margin = new Padding(3, 4, 3, 4);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(365, 27);
            txtMiddleName.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.Location = new Point(417, 88);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(69, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9F);
            txtPhone.Location = new Point(417, 111);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(365, 27);
            txtPhone.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(23, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(23, 182);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(759, 27);
            txtEmail.TabIndex = 9;
            // 
            // lblPassport
            // 
            lblPassport.AutoSize = true;
            lblPassport.Font = new Font("Segoe UI", 9F);
            lblPassport.Location = new Point(23, 227);
            lblPassport.Name = "lblPassport";
            lblPassport.Size = new Size(126, 20);
            lblPassport.TabIndex = 10;
            lblPassport.Text = "Номер паспорта";
            // 
            // txtPassport
            // 
            txtPassport.Font = new Font("Segoe UI", 9F);
            txtPassport.Location = new Point(23, 250);
            txtPassport.Margin = new Padding(3, 4, 3, 4);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(365, 27);
            txtPassport.TabIndex = 11;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F);
            lblAddress.Location = new Point(417, 227);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(51, 20);
            lblAddress.TabIndex = 12;
            lblAddress.Text = "Адрес";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 9F);
            txtAddress.Location = new Point(417, 250);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(365, 92);
            txtAddress.TabIndex = 13;
            // 
            // lblDateBirth
            // 
            lblDateBirth.AutoSize = true;
            lblDateBirth.Font = new Font("Segoe UI", 9F);
            lblDateBirth.Location = new Point(23, 291);
            lblDateBirth.Name = "lblDateBirth";
            lblDateBirth.Size = new Size(116, 20);
            lblDateBirth.TabIndex = 14;
            lblDateBirth.Text = "Дата рождения";
            // 
            // dateBirth
            // 
            dateBirth.Font = new Font("Segoe UI", 9F);
            dateBirth.Format = DateTimePickerFormat.Short;
            dateBirth.Location = new Point(23, 315);
            dateBirth.Margin = new Padding(3, 4, 3, 4);
            dateBirth.Name = "dateBirth";
            dateBirth.Size = new Size(365, 27);
            dateBirth.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(565, 374);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(683, 374);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Отмена";
            // 
            // AddEditGuestForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(817, 424);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPassport);
            Controls.Add(txtPassport);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblDateBirth);
            Controls.Add(dateBirth);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AddEditGuestForm";
            Text = "Гость";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
