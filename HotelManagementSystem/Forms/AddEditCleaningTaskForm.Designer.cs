namespace HotelManagementSystem
{
    partial class AddEditCleaningTaskForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblRoom;
        private ComboBox comboRoom;
        private Label lblEmployee;
        private ComboBox comboEmployee;
        private Label lblTaskType;
        private ComboBox comboTaskType;
        private Label lblScheduledDate;
        private DateTimePicker dateTimePicker;
        private Label lblEstimatedDuration;
        private NumericUpDown numericEstimatedDuration;
        private Label lblNotes;
        private TextBox txtNotes;
        private CheckBox chkIsActive;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblRoom = new Label();
            comboRoom = new ComboBox();
            lblEmployee = new Label();
            comboEmployee = new ComboBox();
            lblTaskType = new Label();
            comboTaskType = new ComboBox();
            lblScheduledDate = new Label();
            dateTimePicker = new DateTimePicker();
            lblEstimatedDuration = new Label();
            numericEstimatedDuration = new NumericUpDown();
            lblNotes = new Label();
            txtNotes = new TextBox();
            chkIsActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericEstimatedDuration).BeginInit();
            SuspendLayout();
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 9F);
            lblRoom.Location = new Point(15, 16);
            lblRoom.Margin = new Padding(2, 0, 2, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(122, 20);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Номер комнаты";
            // 
            // comboRoom
            // 
            comboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRoom.Font = new Font("Segoe UI", 9F);
            comboRoom.Location = new Point(143, 13);
            comboRoom.Margin = new Padding(2);
            comboRoom.Name = "comboRoom";
            comboRoom.Size = new Size(280, 28);
            comboRoom.TabIndex = 1;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Segoe UI", 9F);
            lblEmployee.Location = new Point(55, 63);
            lblEmployee.Margin = new Padding(2, 0, 2, 0);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(82, 20);
            lblEmployee.TabIndex = 2;
            lblEmployee.Text = "Сотрудник";
            // 
            // comboEmployee
            // 
            comboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEmployee.Font = new Font("Segoe UI", 9F);
            comboEmployee.Location = new Point(143, 60);
            comboEmployee.Margin = new Padding(2);
            comboEmployee.Name = "comboEmployee";
            comboEmployee.Size = new Size(280, 28);
            comboEmployee.TabIndex = 3;
            // 
            // lblTaskType
            // 
            lblTaskType.AutoSize = true;
            lblTaskType.Font = new Font("Segoe UI", 9F);
            lblTaskType.Location = new Point(48, 109);
            lblTaskType.Margin = new Padding(2, 0, 2, 0);
            lblTaskType.Name = "lblTaskType";
            lblTaskType.Size = new Size(89, 20);
            lblTaskType.TabIndex = 4;
            lblTaskType.Text = "Тип уборки";
            // 
            // comboTaskType
            // 
            comboTaskType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTaskType.Font = new Font("Segoe UI", 9F);
            comboTaskType.Items.AddRange(new object[] { "Стандартная", "Генеральная", "Техническая" });
            comboTaskType.Location = new Point(143, 106);
            comboTaskType.Margin = new Padding(2);
            comboTaskType.Name = "comboTaskType";
            comboTaskType.Size = new Size(280, 28);
            comboTaskType.TabIndex = 5;
            // 
            // lblScheduledDate
            // 
            lblScheduledDate.AutoSize = true;
            lblScheduledDate.Font = new Font("Segoe UI", 9F);
            lblScheduledDate.Location = new Point(20, 154);
            lblScheduledDate.Margin = new Padding(2, 0, 2, 0);
            lblScheduledDate.Name = "lblScheduledDate";
            lblScheduledDate.Size = new Size(170, 20);
            lblScheduledDate.TabIndex = 6;
            lblScheduledDate.Text = "Запланированная дата";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker.Location = new Point(194, 149);
            dateTimePicker.Margin = new Padding(2);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(227, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // lblEstimatedDuration
            // 
            lblEstimatedDuration.AutoSize = true;
            lblEstimatedDuration.Font = new Font("Segoe UI", 9F);
            lblEstimatedDuration.Location = new Point(20, 192);
            lblEstimatedDuration.Margin = new Padding(2, 0, 2, 0);
            lblEstimatedDuration.Name = "lblEstimatedDuration";
            lblEstimatedDuration.Size = new Size(269, 20);
            lblEstimatedDuration.TabIndex = 8;
            lblEstimatedDuration.Text = "Предполагаемая длительность (мин)";
            // 
            // numericEstimatedDuration
            // 
            numericEstimatedDuration.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericEstimatedDuration.Location = new Point(301, 190);
            numericEstimatedDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEstimatedDuration.Name = "numericEstimatedDuration";
            numericEstimatedDuration.Size = new Size(120, 27);
            numericEstimatedDuration.TabIndex = 9;
            numericEstimatedDuration.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F);
            lblNotes.Location = new Point(20, 242);
            lblNotes.Margin = new Padding(2, 0, 2, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(99, 20);
            lblNotes.TabIndex = 10;
            lblNotes.Text = "Примечания";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtNotes.Location = new Point(15, 264);
            txtNotes.Margin = new Padding(2);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(408, 58);
            txtNotes.TabIndex = 11;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            chkIsActive.Location = new Point(15, 329);
            chkIsActive.Margin = new Padding(2);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(88, 24);
            chkIsActive.TabIndex = 12;
            chkIsActive.Text = "Активна";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(207, 360);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 13;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(323, 360);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Отмена";
            // 
            // AddEditCleaningTaskForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(436, 414);
            Controls.Add(lblRoom);
            Controls.Add(comboRoom);
            Controls.Add(lblEmployee);
            Controls.Add(comboEmployee);
            Controls.Add(lblTaskType);
            Controls.Add(comboTaskType);
            Controls.Add(lblScheduledDate);
            Controls.Add(dateTimePicker);
            Controls.Add(lblEstimatedDuration);
            Controls.Add(numericEstimatedDuration);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(chkIsActive);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "AddEditCleaningTaskForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Задача на уборку";
            ((System.ComponentModel.ISupportInitialize)numericEstimatedDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
