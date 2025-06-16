namespace HotelManagementSystem
{
    partial class AddEditTariffForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTariffName;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown numericDiscount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtTariffName = new TextBox();
            lblDiscount = new Label();
            numericDiscount = new NumericUpDown();
            lblDescription = new Label();
            txtDescription = new TextBox();
            chkIsActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericDiscount).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 24);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Название тарифа";
            // 
            // txtTariffName
            // 
            txtTariffName.BackColor = SystemColors.Window;
            txtTariffName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtTariffName.Location = new Point(20, 38);
            txtTariffName.Name = "txtTariffName";
            txtTariffName.Size = new Size(560, 27);
            txtTariffName.TabIndex = 1;
            // 
            // lblDiscount
            // 
            lblDiscount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDiscount.ForeColor = Color.Black;
            lblDiscount.Location = new Point(20, 84);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(180, 20);
            lblDiscount.TabIndex = 2;
            lblDiscount.Text = "Процент скидки";
            // 
            // numericDiscount
            // 
            numericDiscount.DecimalPlaces = 2;
            numericDiscount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericDiscount.Location = new Point(20, 107);
            numericDiscount.Name = "numericDiscount";
            numericDiscount.Size = new Size(150, 27);
            numericDiscount.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDescription.ForeColor = Color.Black;
            lblDescription.Location = new Point(20, 152);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(180, 20);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Описание";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDescription.Location = new Point(20, 175);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(560, 90);
            txtDescription.TabIndex = 5;
            // 
            // chkIsActive
            // 
            chkIsActive.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            chkIsActive.Location = new Point(20, 271);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(112, 25);
            chkIsActive.TabIndex = 6;
            chkIsActive.Text = "Активен";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(364, 309);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 7;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(481, 309);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddEditTariffForm
            // 
            AcceptButton = btnSave;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            CancelButton = btnCancel;
            ClientSize = new Size(600, 360);
            Controls.Add(lblTitle);
            Controls.Add(txtTariffName);
            Controls.Add(lblDiscount);
            Controls.Add(numericDiscount);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(chkIsActive);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditTariffForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Тариф";
            ((System.ComponentModel.ISupportInitialize)numericDiscount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
