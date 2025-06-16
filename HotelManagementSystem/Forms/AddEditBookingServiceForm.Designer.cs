namespace HotelManagementSystem.Forms
{
    partial class AddEditBookingServiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancel = new Button();
            btnSave = new Button();
            serviceComboBox = new ComboBox();
            serviceLabel = new Label();
            quantityLabel = new Label();
            numericQuantity = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(573, 111);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(459, 111);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // serviceComboBox
            // 
            serviceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serviceComboBox.FormattingEnabled = true;
            serviceComboBox.Location = new Point(12, 45);
            serviceComboBox.Name = "serviceComboBox";
            serviceComboBox.Size = new Size(300, 28);
            serviceComboBox.TabIndex = 19;
            // 
            // serviceLabel
            // 
            serviceLabel.AutoSize = true;
            serviceLabel.Location = new Point(12, 22);
            serviceLabel.Name = "serviceLabel";
            serviceLabel.Size = new Size(54, 20);
            serviceLabel.TabIndex = 18;
            serviceLabel.Text = "Услуга";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new Point(355, 23);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(90, 20);
            quantityLabel.TabIndex = 20;
            quantityLabel.Text = "Количество";
            // 
            // numericQuantity
            // 
            numericQuantity.Location = new Point(355, 46);
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(150, 27);
            numericQuantity.TabIndex = 21;
            // 
            // AddEditBookingServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 167);
            Controls.Add(numericQuantity);
            Controls.Add(quantityLabel);
            Controls.Add(serviceComboBox);
            Controls.Add(serviceLabel);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "AddEditBookingServiceForm";
            Text = "Услуга бронирования";
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private ComboBox serviceComboBox;
        private Label serviceLabel;
        private Label quantityLabel;
        private NumericUpDown numericQuantity;
    }
}