namespace HotelManagementSystem
{
    partial class MaintenanceTasksForm
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
            maintenanceTasksDataGridView = new DataGridView();
            btnAddTask = new Button();
            btnEditTask = new Button();
            btnDeleteTask = new Button();
            btnCompleteTask = new Button();
            ((System.ComponentModel.ISupportInitialize)maintenanceTasksDataGridView).BeginInit();
            SuspendLayout();
            // 
            // maintenanceTasksDataGridView
            // 
            maintenanceTasksDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            maintenanceTasksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            maintenanceTasksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            maintenanceTasksDataGridView.Location = new Point(14, 16);
            maintenanceTasksDataGridView.Margin = new Padding(3, 4, 3, 4);
            maintenanceTasksDataGridView.MultiSelect = false;
            maintenanceTasksDataGridView.Name = "maintenanceTasksDataGridView";
            maintenanceTasksDataGridView.ReadOnly = true;
            maintenanceTasksDataGridView.RowHeadersWidth = 51;
            maintenanceTasksDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            maintenanceTasksDataGridView.Size = new Size(869, 533);
            maintenanceTasksDataGridView.TabIndex = 0;
            // 
            // btnAddTask
            // 
            btnAddTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddTask.Location = new Point(14, 560);
            btnAddTask.Margin = new Padding(3, 4, 3, 4);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(137, 53);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "Создать задачу";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnEditTask
            // 
            btnEditTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditTask.Location = new Point(171, 560);
            btnEditTask.Margin = new Padding(3, 4, 3, 4);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(137, 53);
            btnEditTask.TabIndex = 2;
            btnEditTask.Text = "Изменить задачу";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteTask.Location = new Point(329, 560);
            btnDeleteTask.Margin = new Padding(3, 4, 3, 4);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(137, 53);
            btnDeleteTask.TabIndex = 3;
            btnDeleteTask.Text = "Удалить задачу";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnCompleteTask
            // 
            btnCompleteTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCompleteTask.Location = new Point(746, 560);
            btnCompleteTask.Margin = new Padding(3, 4, 3, 4);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(137, 53);
            btnCompleteTask.TabIndex = 4;
            btnCompleteTask.Text = "Задача выполнена";
            btnCompleteTask.UseVisualStyleBackColor = true;
            btnCompleteTask.Click += btnCompleteTask_Click;
            // 
            // MaintenanceTasksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 628);
            Controls.Add(btnCompleteTask);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnEditTask);
            Controls.Add(btnAddTask);
            Controls.Add(maintenanceTasksDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MaintenanceTasksForm";
            Text = "Задачи техобслуживания";
            ((System.ComponentModel.ISupportInitialize)maintenanceTasksDataGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView maintenanceTasksDataGridView;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private Button btnCompleteTask;
    }
}
