namespace HotelManagementSystem
{
    partial class AddEditMaintenanceTaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbRoom;
        private ComboBox cmbEmployee;
        private ComboBox cmbPriority;
        private ComboBox cmbStatus;
        private DateTimePicker dateScheduled;
        private NumericUpDown nudCost;
        private TextBox txtDescription;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;
        private Label lblRoom;
        private Label lblEmployee;
        private Label lblPriority;
        private Label lblStatus;
        private Label lblScheduledDate;
        private Label lblCost;
        private Label lblDescription;
        private Label lblNotes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbRoom = new ComboBox();
            cmbEmployee = new ComboBox();
            cmbPriority = new ComboBox();
            cmbStatus = new ComboBox();
            dateScheduled = new DateTimePicker();
            nudCost = new NumericUpDown();
            txtDescription = new TextBox();
            txtNotes = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblRoom = new Label();
            lblEmployee = new Label();
            lblPriority = new Label();
            lblStatus = new Label();
            lblScheduledDate = new Label();
            lblCost = new Label();
            lblDescription = new Label();
            lblNotes = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCost).BeginInit();
            SuspendLayout();
            // 
            // cmbRoom
            // 
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.Location = new Point(25, 35);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(250, 28);
            cmbRoom.TabIndex = 1;
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.Location = new Point(300, 35);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(250, 28);
            cmbEmployee.TabIndex = 3;
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Location = new Point(25, 90);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(250, 28);
            cmbPriority.TabIndex = 5;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(300, 90);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(250, 28);
            cmbStatus.TabIndex = 7;
            // 
            // dateScheduled
            // 
            dateScheduled.Format = DateTimePickerFormat.Short;
            dateScheduled.Location = new Point(25, 145);
            dateScheduled.Name = "dateScheduled";
            dateScheduled.Size = new Size(250, 27);
            dateScheduled.TabIndex = 9;
            // 
            // nudCost
            // 
            nudCost.DecimalPlaces = 2;
            nudCost.Location = new Point(300, 145);
            nudCost.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCost.Name = "nudCost";
            nudCost.Size = new Size(250, 27);
            nudCost.TabIndex = 11;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(25, 200);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(525, 60);
            txtDescription.TabIndex = 13;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(25, 290);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(525, 60);
            txtNotes.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(375, 365);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(490, 365);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Отмена";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(25, 15);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(57, 20);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Номер";
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(300, 15);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(82, 20);
            lblEmployee.TabIndex = 2;
            lblEmployee.Text = "Сотрудник";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(25, 70);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(85, 20);
            lblPriority.TabIndex = 4;
            lblPriority.Text = "Приоритет";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(300, 70);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Статус";
            // 
            // lblScheduledDate
            // 
            lblScheduledDate.AutoSize = true;
            lblScheduledDate.Location = new Point(25, 125);
            lblScheduledDate.Name = "lblScheduledDate";
            lblScheduledDate.Size = new Size(41, 20);
            lblScheduledDate.TabIndex = 8;
            lblScheduledDate.Text = "Дата";
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(300, 125);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(105, 20);
            lblCost.TabIndex = 10;
            lblCost.Text = "Стоимость (₽)";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(25, 180);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(79, 20);
            lblDescription.TabIndex = 12;
            lblDescription.Text = "Описание";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(25, 270);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(99, 20);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "Примечания";
            // 
            // AddEditMaintenanceTaskForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(600, 420);
            Controls.Add(lblRoom);
            Controls.Add(cmbRoom);
            Controls.Add(lblEmployee);
            Controls.Add(cmbEmployee);
            Controls.Add(lblPriority);
            Controls.Add(cmbPriority);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(lblScheduledDate);
            Controls.Add(dateScheduled);
            Controls.Add(lblCost);
            Controls.Add(nudCost);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditMaintenanceTaskForm";
            Text = "Задача Техобслуживания";
            ((System.ComponentModel.ISupportInitialize)nudCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
