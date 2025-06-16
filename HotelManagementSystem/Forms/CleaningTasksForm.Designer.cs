namespace HotelManagementSystem
{
    partial class CleaningTasksForm
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
            cleaningTasksDataGridView = new DataGridView();
            btnAddTask = new Button();
            btnEditTask = new Button();
            btnDeleteTask = new Button();
            btnCompleteTask = new Button();
            ((System.ComponentModel.ISupportInitialize)cleaningTasksDataGridView).BeginInit();
            SuspendLayout();
            // 
            // cleaningTasksDataGridView
            // 
            cleaningTasksDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cleaningTasksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cleaningTasksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cleaningTasksDataGridView.Location = new Point(14, 16);
            cleaningTasksDataGridView.Margin = new Padding(3, 4, 3, 4);
            cleaningTasksDataGridView.MultiSelect = false;
            cleaningTasksDataGridView.Name = "cleaningTasksDataGridView";
            cleaningTasksDataGridView.ReadOnly = true;
            cleaningTasksDataGridView.RowHeadersWidth = 51;
            cleaningTasksDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cleaningTasksDataGridView.Size = new Size(869, 533);
            cleaningTasksDataGridView.TabIndex = 0;
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
            // CleaningTasksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 628);
            Controls.Add(btnCompleteTask);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnEditTask);
            Controls.Add(btnAddTask);
            Controls.Add(cleaningTasksDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CleaningTasksForm";
            Text = "Задачи уборки";
            ((System.ComponentModel.ISupportInitialize)cleaningTasksDataGridView).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView cleaningTasksDataGridView;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private Button btnCompleteTask;
    }
}
