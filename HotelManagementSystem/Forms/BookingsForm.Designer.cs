namespace HotelManagementSystem
{
    partial class BookingsForm
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
            bookingsDataGridView = new DataGridView();
            btnAddBooking = new Button();
            btnEditBooking = new Button();
            btnCancelBooking = new Button();
            btnBookingService = new Button();
            ((System.ComponentModel.ISupportInitialize)bookingsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // bookingsDataGridView
            // 
            bookingsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bookingsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bookingsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingsDataGridView.Location = new Point(14, 16);
            bookingsDataGridView.Margin = new Padding(3, 4, 3, 4);
            bookingsDataGridView.MultiSelect = false;
            bookingsDataGridView.Name = "bookingsDataGridView";
            bookingsDataGridView.ReadOnly = true;
            bookingsDataGridView.RowHeadersWidth = 51;
            bookingsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bookingsDataGridView.Size = new Size(983, 533);
            bookingsDataGridView.TabIndex = 0;
            // 
            // btnAddBooking
            // 
            btnAddBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddBooking.Location = new Point(14, 560);
            btnAddBooking.Margin = new Padding(3, 4, 3, 4);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(137, 53);
            btnAddBooking.TabIndex = 1;
            btnAddBooking.Text = "Новое бронирование";
            btnAddBooking.UseVisualStyleBackColor = true;
            btnAddBooking.Click += btnAddBooking_Click;
            // 
            // btnEditBooking
            // 
            btnEditBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditBooking.Location = new Point(171, 560);
            btnEditBooking.Margin = new Padding(3, 4, 3, 4);
            btnEditBooking.Name = "btnEditBooking";
            btnEditBooking.Size = new Size(137, 53);
            btnEditBooking.TabIndex = 2;
            btnEditBooking.Text = "Редактировать";
            btnEditBooking.UseVisualStyleBackColor = true;
            btnEditBooking.Click += btnEditBooking_Click;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelBooking.Location = new Point(329, 560);
            btnCancelBooking.Margin = new Padding(3, 4, 3, 4);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(137, 53);
            btnCancelBooking.TabIndex = 3;
            btnCancelBooking.Text = "Отменить бронь";
            btnCancelBooking.UseVisualStyleBackColor = true;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnBookingService
            // 
            btnBookingService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBookingService.Location = new Point(860, 562);
            btnBookingService.Margin = new Padding(3, 4, 3, 4);
            btnBookingService.Name = "btnBookingService";
            btnBookingService.Size = new Size(137, 53);
            btnBookingService.TabIndex = 4;
            btnBookingService.Text = "Редактировать услуги";
            btnBookingService.UseVisualStyleBackColor = true;
            btnBookingService.Click += btnBookingService_Click;
            // 
            // BookingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 628);
            Controls.Add(btnBookingService);
            Controls.Add(btnCancelBooking);
            Controls.Add(btnEditBooking);
            Controls.Add(btnAddBooking);
            Controls.Add(bookingsDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BookingsForm";
            Text = "Управление бронированиями";
            ((System.ComponentModel.ISupportInitialize)bookingsDataGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView bookingsDataGridView;
        private System.Windows.Forms.Button btnAddBooking;
        private System.Windows.Forms.Button btnEditBooking;
        private System.Windows.Forms.Button btnCancelBooking;
        private Button btnBookingService;
    }
}
