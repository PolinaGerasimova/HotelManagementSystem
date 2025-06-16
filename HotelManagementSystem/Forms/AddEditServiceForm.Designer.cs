namespace HotelManagementSystem
{
    partial class AddEditServiceForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtServiceName;
        private Label lblPrice;
        private NumericUpDown numericPrice;
        private Label lblDescription;
        private TextBox txtDescription;
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
            lblName = new Label();
            txtServiceName = new TextBox();
            lblPrice = new Label();
            numericPrice = new NumericUpDown();
            lblDescription = new Label();
            txtDescription = new TextBox();
            chkIsActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(20, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(200, 23);
            lblName.TabIndex = 1;
            lblName.Text = "Название услуги";
            // 
            // txtServiceName
            // 
            txtServiceName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtServiceName.Location = new Point(20, 35);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(560, 27);
            txtServiceName.TabIndex = 2;
            // 
            // lblPrice
            // 
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(20, 75);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Цена, ₽";
            // 
            // numericPrice
            // 
            numericPrice.DecimalPlaces = 2;
            numericPrice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericPrice.Location = new Point(20, 101);
            numericPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(200, 27);
            numericPrice.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDescription.ForeColor = Color.Black;
            lblDescription.Location = new Point(20, 142);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(136, 23);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Описание (необязательно)";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDescription.Location = new Point(20, 168);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(560, 100);
            txtDescription.TabIndex = 6;
            // 
            // chkIsActive
            // 
            chkIsActive.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            chkIsActive.ForeColor = Color.FromArgb(17, 24, 39);
            chkIsActive.Location = new Point(20, 274);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(136, 53);
            chkIsActive.TabIndex = 7;
            chkIsActive.Text = "Активна";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(376, 292);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 35);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(481, 291);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            // 
            // AddEditServiceForm
            // 
            AcceptButton = btnSave;
            BackColor = SystemColors.Control;
            CancelButton = btnCancel;
            ClientSize = new Size(600, 338);
            Controls.Add(lblName);
            Controls.Add(txtServiceName);
            Controls.Add(lblPrice);
            Controls.Add(numericPrice);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(chkIsActive);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddEditServiceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить/Редактировать услугу";
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
