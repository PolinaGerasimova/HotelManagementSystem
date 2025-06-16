namespace HotelManagementSystem
{
    partial class GuestsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.guestsDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.btnEditGuest = new System.Windows.Forms.Button();
            this.btnDeleteGuest = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.guestsDataGridView)).BeginInit();
            this.SuspendLayout();

            // guestsDataGridView
            this.guestsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
            this.guestsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guestsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.guestsDataGridView.MultiSelect = false;
            this.guestsDataGridView.Name = "guestsDataGridView";
            this.guestsDataGridView.ReadOnly = true;
            this.guestsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guestsDataGridView.Size = new System.Drawing.Size(760, 400);
            this.guestsDataGridView.TabIndex = 0;

            // btnAddGuest
            this.btnAddGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddGuest.Location = new System.Drawing.Point(12, 420);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(120, 40);
            this.btnAddGuest.Text = "Добавить гостя";
            this.btnAddGuest.UseVisualStyleBackColor = true;
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);

            // btnEditGuest
            this.btnEditGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditGuest.Location = new System.Drawing.Point(150, 420);
            this.btnEditGuest.Name = "btnEditGuest";
            this.btnEditGuest.Size = new System.Drawing.Size(120, 40);
            this.btnEditGuest.Text = "Редактировать";
            this.btnEditGuest.UseVisualStyleBackColor = true;
            this.btnEditGuest.Click += new System.EventHandler(this.btnEditGuest_Click);

            // btnDeleteGuest
            this.btnDeleteGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteGuest.Location = new System.Drawing.Point(288, 420);
            this.btnDeleteGuest.Name = "btnDeleteGuest";
            this.btnDeleteGuest.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteGuest.Text = "Удалить гостя";
            this.btnDeleteGuest.UseVisualStyleBackColor = true;
            this.btnDeleteGuest.Click += new System.EventHandler(this.btnDeleteGuest_Click);

            // GuestsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.btnDeleteGuest);
            this.Controls.Add(this.btnEditGuest);
            this.Controls.Add(this.btnAddGuest);
            this.Controls.Add(this.guestsDataGridView);
            this.Name = "GuestsForm";
            this.Text = "Управление гостями";

            ((System.ComponentModel.ISupportInitialize)(this.guestsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView guestsDataGridView;
        private System.Windows.Forms.Button btnAddGuest;
        private System.Windows.Forms.Button btnEditGuest;
        private System.Windows.Forms.Button btnDeleteGuest;
    }
}
