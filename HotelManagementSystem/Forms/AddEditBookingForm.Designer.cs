namespace HotelManagementSystem
{
    partial class AddEditBookingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label guestLabel;
        private System.Windows.Forms.ComboBox guestComboBox;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.ComboBox roomComboBox;
        private System.Windows.Forms.Label tariffLabel;
        private System.Windows.Forms.ComboBox tariffComboBox;
        private System.Windows.Forms.Label checkInLabel;
        private System.Windows.Forms.DateTimePicker checkInDateTimePicker;
        private System.Windows.Forms.Label checkOutLabel;
        private System.Windows.Forms.DateTimePicker checkOutDateTimePicker;
        private System.Windows.Forms.Label guestsCountLabel;
        private System.Windows.Forms.NumericUpDown numberOfGuestsNumeric;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            guestLabel = new Label();
            guestComboBox = new ComboBox();
            roomLabel = new Label();
            roomComboBox = new ComboBox();
            tariffLabel = new Label();
            tariffComboBox = new ComboBox();
            checkInLabel = new Label();
            checkInDateTimePicker = new DateTimePicker();
            checkOutLabel = new Label();
            checkOutDateTimePicker = new DateTimePicker();
            guestsCountLabel = new Label();
            numberOfGuestsNumeric = new NumericUpDown();
            notesLabel = new Label();
            notesTextBox = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            statusComboBox = new ComboBox();
            lblBookingStatus = new Label();
            totalCostLabel = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numberOfGuestsNumeric).BeginInit();
            SuspendLayout();
            // 
            // guestLabel
            // 
            guestLabel.AutoSize = true;
            guestLabel.Location = new Point(20, 20);
            guestLabel.Name = "guestLabel";
            guestLabel.Size = new Size(46, 20);
            guestLabel.TabIndex = 0;
            guestLabel.Text = "Гость";
            // 
            // guestComboBox
            // 
            guestComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            guestComboBox.FormattingEnabled = true;
            guestComboBox.Location = new Point(20, 38);
            guestComboBox.Name = "guestComboBox";
            guestComboBox.Size = new Size(300, 28);
            guestComboBox.TabIndex = 1;
            // 
            // roomLabel
            // 
            roomLabel.AutoSize = true;
            roomLabel.Location = new Point(360, 20);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(122, 20);
            roomLabel.TabIndex = 2;
            roomLabel.Text = "Номер комнаты";
            // 
            // roomComboBox
            // 
            roomComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roomComboBox.FormattingEnabled = true;
            roomComboBox.Location = new Point(360, 38);
            roomComboBox.Name = "roomComboBox";
            roomComboBox.Size = new Size(300, 28);
            roomComboBox.TabIndex = 3;
            // 
            // tariffLabel
            // 
            tariffLabel.AutoSize = true;
            tariffLabel.Location = new Point(20, 75);
            tariffLabel.Name = "tariffLabel";
            tariffLabel.Size = new Size(53, 20);
            tariffLabel.TabIndex = 4;
            tariffLabel.Text = "Тариф";
            // 
            // tariffComboBox
            // 
            tariffComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tariffComboBox.FormattingEnabled = true;
            tariffComboBox.Location = new Point(20, 93);
            tariffComboBox.Name = "tariffComboBox";
            tariffComboBox.Size = new Size(300, 28);
            tariffComboBox.TabIndex = 5;
            // 
            // checkInLabel
            // 
            checkInLabel.AutoSize = true;
            checkInLabel.Location = new Point(360, 75);
            checkInLabel.Name = "checkInLabel";
            checkInLabel.Size = new Size(91, 20);
            checkInLabel.TabIndex = 6;
            checkInLabel.Text = "Дата заезда";
            // 
            // checkInDateTimePicker
            // 
            checkInDateTimePicker.Format = DateTimePickerFormat.Short;
            checkInDateTimePicker.Location = new Point(360, 93);
            checkInDateTimePicker.Name = "checkInDateTimePicker";
            checkInDateTimePicker.Size = new Size(150, 27);
            checkInDateTimePicker.TabIndex = 7;
            // 
            // checkOutLabel
            // 
            checkOutLabel.AutoSize = true;
            checkOutLabel.Location = new Point(520, 75);
            checkOutLabel.Name = "checkOutLabel";
            checkOutLabel.Size = new Size(95, 20);
            checkOutLabel.TabIndex = 8;
            checkOutLabel.Text = "Дата выезда";
            // 
            // checkOutDateTimePicker
            // 
            checkOutDateTimePicker.Format = DateTimePickerFormat.Short;
            checkOutDateTimePicker.Location = new Point(520, 93);
            checkOutDateTimePicker.Name = "checkOutDateTimePicker";
            checkOutDateTimePicker.Size = new Size(140, 27);
            checkOutDateTimePicker.TabIndex = 9;
            // 
            // guestsCountLabel
            // 
            guestsCountLabel.AutoSize = true;
            guestsCountLabel.Location = new Point(20, 130);
            guestsCountLabel.Name = "guestsCountLabel";
            guestsCountLabel.Size = new Size(139, 20);
            guestsCountLabel.TabIndex = 10;
            guestsCountLabel.Text = "Количество гостей";
            // 
            // numberOfGuestsNumeric
            // 
            numberOfGuestsNumeric.Location = new Point(20, 148);
            numberOfGuestsNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberOfGuestsNumeric.Name = "numberOfGuestsNumeric";
            numberOfGuestsNumeric.Size = new Size(120, 27);
            numberOfGuestsNumeric.TabIndex = 11;
            numberOfGuestsNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new Point(20, 185);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new Size(99, 20);
            notesLabel.TabIndex = 12;
            notesLabel.Text = "Примечания";
            // 
            // notesTextBox
            // 
            notesTextBox.Location = new Point(20, 203);
            notesTextBox.Multiline = true;
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new Size(640, 80);
            notesTextBox.TabIndex = 13;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(447, 300);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(99, 35);
            saveButton.TabIndex = 14;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(561, 300);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 35);
            cancelButton.TabIndex = 15;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(360, 147);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(300, 28);
            statusComboBox.TabIndex = 17;
            // 
            // lblBookingStatus
            // 
            lblBookingStatus.AutoSize = true;
            lblBookingStatus.Location = new Point(360, 129);
            lblBookingStatus.Name = "lblBookingStatus";
            lblBookingStatus.Size = new Size(52, 20);
            lblBookingStatus.TabIndex = 16;
            lblBookingStatus.Text = "Статус";
            // 
            // totalCostLabel
            // 
            totalCostLabel.AutoSize = true;
            totalCostLabel.Location = new Point(109, 307);
            totalCostLabel.Name = "totalCostLabel";
            totalCostLabel.Size = new Size(57, 20);
            totalCostLabel.TabIndex = 18;
            totalCostLabel.Text = "000000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 307);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 19;
            label1.Text = "Стоимость";
            // 
            // AddEditBookingForm
            // 
            AcceptButton = saveButton;
            CancelButton = cancelButton;
            ClientSize = new Size(684, 361);
            Controls.Add(label1);
            Controls.Add(totalCostLabel);
            Controls.Add(statusComboBox);
            Controls.Add(lblBookingStatus);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(notesTextBox);
            Controls.Add(notesLabel);
            Controls.Add(numberOfGuestsNumeric);
            Controls.Add(guestsCountLabel);
            Controls.Add(checkOutDateTimePicker);
            Controls.Add(checkOutLabel);
            Controls.Add(checkInDateTimePicker);
            Controls.Add(checkInLabel);
            Controls.Add(tariffComboBox);
            Controls.Add(tariffLabel);
            Controls.Add(roomComboBox);
            Controls.Add(roomLabel);
            Controls.Add(guestComboBox);
            Controls.Add(guestLabel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditBookingForm";
            Text = "Бронирование";
            ((System.ComponentModel.ISupportInitialize)numberOfGuestsNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox statusComboBox;
        private Label lblBookingStatus;
        private Label totalCostLabel;
        private Label label1;
    }
}
