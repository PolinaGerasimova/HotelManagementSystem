namespace HotelManagementSystem.Forms
{
    partial class BookingServicesForm
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
            servicesDataGridView = new DataGridView();
            btnCancelService = new Button();
            btnEditService = new Button();
            btnAddService = new Button();
            ((System.ComponentModel.ISupportInitialize)servicesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // servicesDataGridView
            // 
            servicesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            servicesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            servicesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            servicesDataGridView.Location = new Point(15, 13);
            servicesDataGridView.Margin = new Padding(3, 4, 3, 4);
            servicesDataGridView.MultiSelect = false;
            servicesDataGridView.Name = "servicesDataGridView";
            servicesDataGridView.ReadOnly = true;
            servicesDataGridView.RowHeadersWidth = 51;
            servicesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            servicesDataGridView.Size = new Size(983, 533);
            servicesDataGridView.TabIndex = 1;
            // 
            // btnCancelService
            // 
            btnCancelService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelService.Location = new Point(329, 562);
            btnCancelService.Margin = new Padding(3, 4, 3, 4);
            btnCancelService.Name = "btnCancelService";
            btnCancelService.Size = new Size(137, 53);
            btnCancelService.TabIndex = 6;
            btnCancelService.Text = "Удалить услугу";
            btnCancelService.UseVisualStyleBackColor = true;
            btnCancelService.Click += btnDeleteService_Click;
            // 
            // btnEditService
            // 
            btnEditService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditService.Location = new Point(171, 562);
            btnEditService.Margin = new Padding(3, 4, 3, 4);
            btnEditService.Name = "btnEditService";
            btnEditService.Size = new Size(137, 53);
            btnEditService.TabIndex = 5;
            btnEditService.Text = "Редактировать";
            btnEditService.UseVisualStyleBackColor = true;
            btnEditService.Click += btnEditService_Click;
            // 
            // btnAddService
            // 
            btnAddService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddService.Location = new Point(14, 562);
            btnAddService.Margin = new Padding(3, 4, 3, 4);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(137, 53);
            btnAddService.TabIndex = 4;
            btnAddService.Text = "Новая услуга";
            btnAddService.UseVisualStyleBackColor = true;
            btnAddService.Click += btnAddService_Click;
            // 
            // BookingServicesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 628);
            Controls.Add(btnCancelService);
            Controls.Add(btnEditService);
            Controls.Add(btnAddService);
            Controls.Add(servicesDataGridView);
            Name = "BookingServicesForm";
            Text = "Услуги бронирования";
            ((System.ComponentModel.ISupportInitialize)servicesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView servicesDataGridView;
        private Button btnCancelService;
        private Button btnEditService;
        private Button btnAddService;
    }
}