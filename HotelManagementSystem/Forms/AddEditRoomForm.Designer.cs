using HotelManagementSystem.Models;
using System.Linq;

namespace HotelManagementSystem.Forms
{
    partial class AddEditRoomForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtRoomNumber;
        private ComboBox cmbCategory;
        private NumericUpDown numMaxOccupancy;
        private NumericUpDown numBasePrice;
        private ComboBox cmbStatus;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;
        private Label lblRoomNumber;
        private Label lblCategory;
        private Label lblBasePrice;
        private Label lblStatus;
        private Label lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtRoomNumber = new TextBox();
            cmbCategory = new ComboBox();
            numMaxOccupancy = new NumericUpDown();
            numBasePrice = new NumericUpDown();
            cmbStatus = new ComboBox();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblRoomNumber = new Label();
            lblCategory = new Label();
            lblBasePrice = new Label();
            lblStatus = new Label();
            lblDescription = new Label();
            lblMaxOccupancy = new Label();
            ((System.ComponentModel.ISupportInitialize)numMaxOccupancy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBasePrice).BeginInit();
            SuspendLayout();
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(20, 38);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(300, 27);
            txtRoomNumber.TabIndex = 1;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(350, 38);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(300, 28);
            cmbCategory.TabIndex = 3;
            // 
            // numMaxOccupancy
            // 
            numMaxOccupancy.Location = new Point(20, 93);
            numMaxOccupancy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxOccupancy.Name = "numMaxOccupancy";
            numMaxOccupancy.Size = new Size(120, 27);
            numMaxOccupancy.TabIndex = 5;
            numMaxOccupancy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numBasePrice
            // 
            numBasePrice.DecimalPlaces = 2;
            numBasePrice.Location = new Point(160, 93);
            numBasePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numBasePrice.Name = "numBasePrice";
            numBasePrice.Size = new Size(160, 27);
            numBasePrice.TabIndex = 7;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(350, 93);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(300, 28);
            cmbStatus.TabIndex = 9;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 148);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(630, 70);
            txtDescription.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(436, 243);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 14;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(551, 243);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Location = new Point(20, 17);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(122, 20);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "Номер комнаты";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(350, 17);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(81, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Категория";
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Location = new Point(163, 68);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(161, 20);
            lblBasePrice.TabIndex = 6;
            lblBasePrice.Text = "Базовая цена за ночь";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(350, 75);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Статус";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 128);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(79, 20);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Описание";
            // 
            // lblMaxOccupancy
            // 
            lblMaxOccupancy.AutoSize = true;
            lblMaxOccupancy.Location = new Point(24, 70);
            lblMaxOccupancy.Name = "lblMaxOccupancy";
            lblMaxOccupancy.Size = new Size(100, 20);
            lblMaxOccupancy.TabIndex = 16;
            lblMaxOccupancy.Text = "Вместимость";
            // 
            // AddEditRoomForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(684, 295);
            Controls.Add(lblMaxOccupancy);
            Controls.Add(lblRoomNumber);
            Controls.Add(txtRoomNumber);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(numMaxOccupancy);
            Controls.Add(lblBasePrice);
            Controls.Add(numBasePrice);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditRoomForm";
            Text = "Номер";
            ((System.ComponentModel.ISupportInitialize)numMaxOccupancy).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBasePrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaxOccupancy;
    }
}
