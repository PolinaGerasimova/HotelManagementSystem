namespace HotelManagementSystem.Forms
{
    partial class RoomsForm
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
            roomsDataGridView = new DataGridView();
            btnAddRoom = new Button();
            btnEditRoom = new Button();
            btnDeleteRoom = new Button();
            ((System.ComponentModel.ISupportInitialize)roomsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // roomsDataGridView
            // 
            roomsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roomsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            roomsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            roomsDataGridView.Location = new Point(14, 16);
            roomsDataGridView.Margin = new Padding(3, 4, 3, 4);
            roomsDataGridView.MultiSelect = false;
            roomsDataGridView.Name = "roomsDataGridView";
            roomsDataGridView.ReadOnly = true;
            roomsDataGridView.RowHeadersWidth = 51;
            roomsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            roomsDataGridView.Size = new Size(869, 533);
            roomsDataGridView.TabIndex = 0;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddRoom.Location = new Point(14, 560);
            btnAddRoom.Margin = new Padding(3, 4, 3, 4);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(137, 53);
            btnAddRoom.TabIndex = 1;
            btnAddRoom.Text = "Добавить номер";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnEditRoom
            // 
            btnEditRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditRoom.Location = new Point(171, 560);
            btnEditRoom.Margin = new Padding(3, 4, 3, 4);
            btnEditRoom.Name = "btnEditRoom";
            btnEditRoom.Size = new Size(137, 53);
            btnEditRoom.TabIndex = 2;
            btnEditRoom.Text = "Редактировать";
            btnEditRoom.UseVisualStyleBackColor = true;
            btnEditRoom.Click += btnEditRoom_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteRoom.Location = new Point(329, 560);
            btnDeleteRoom.Margin = new Padding(3, 4, 3, 4);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(137, 53);
            btnDeleteRoom.TabIndex = 3;
            btnDeleteRoom.Text = "Удалить номер";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // RoomsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 628);
            Controls.Add(btnDeleteRoom);
            Controls.Add(btnEditRoom);
            Controls.Add(btnAddRoom);
            Controls.Add(roomsDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RoomsForm";
            Text = "Управление номерами";
            ((System.ComponentModel.ISupportInitialize)roomsDataGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView roomsDataGridView;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnEditRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
    }
}
