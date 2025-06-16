namespace HotelManagementSystem
{
    partial class TariffsForm
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
            this.tariffsDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAddTariff = new System.Windows.Forms.Button();
            this.btnEditTariff = new System.Windows.Forms.Button();
            this.btnDeleteTariff = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.tariffsDataGridView)).BeginInit();
            this.SuspendLayout();

            // tariffsDataGridView
            this.tariffsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                | System.Windows.Forms.AnchorStyles.Left)
                                                | System.Windows.Forms.AnchorStyles.Right)));
            this.tariffsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tariffsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tariffsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.tariffsDataGridView.MultiSelect = false;
            this.tariffsDataGridView.Name = "tariffsDataGridView";
            this.tariffsDataGridView.ReadOnly = true;
            this.tariffsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tariffsDataGridView.Size = new System.Drawing.Size(760, 400);
            this.tariffsDataGridView.TabIndex = 0;

            // btnAddTariff
            this.btnAddTariff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddTariff.Location = new System.Drawing.Point(12, 420);
            this.btnAddTariff.Name = "btnAddTariff";
            this.btnAddTariff.Size = new System.Drawing.Size(120, 40);
            this.btnAddTariff.TabIndex = 1;
            this.btnAddTariff.Text = "Добавить тариф";
            this.btnAddTariff.UseVisualStyleBackColor = true;
            this.btnAddTariff.Click += new System.EventHandler(this.btnAddTariff_Click);

            // btnEditTariff
            this.btnEditTariff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditTariff.Location = new System.Drawing.Point(150, 420);
            this.btnEditTariff.Name = "btnEditTariff";
            this.btnEditTariff.Size = new System.Drawing.Size(120, 40);
            this.btnEditTariff.TabIndex = 2;
            this.btnEditTariff.Text = "Редактировать";
            this.btnEditTariff.UseVisualStyleBackColor = true;
            this.btnEditTariff.Click += new System.EventHandler(this.btnEditTariff_Click);

            // btnDeleteTariff
            this.btnDeleteTariff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteTariff.Location = new System.Drawing.Point(288, 420);
            this.btnDeleteTariff.Name = "btnDeleteTariff";
            this.btnDeleteTariff.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteTariff.TabIndex = 3;
            this.btnDeleteTariff.Text = "Удалить тариф";
            this.btnDeleteTariff.UseVisualStyleBackColor = true;
            this.btnDeleteTariff.Click += new System.EventHandler(this.btnDeleteTariff_Click);

            // TariffsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.btnDeleteTariff);
            this.Controls.Add(this.btnEditTariff);
            this.Controls.Add(this.btnAddTariff);
            this.Controls.Add(this.tariffsDataGridView);
            this.Name = "TariffsForm";
            this.Text = "Управление тарифами";

            ((System.ComponentModel.ISupportInitialize)(this.tariffsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView tariffsDataGridView;
        private System.Windows.Forms.Button btnAddTariff;
        private System.Windows.Forms.Button btnEditTariff;
        private System.Windows.Forms.Button btnDeleteTariff;
    }
}
