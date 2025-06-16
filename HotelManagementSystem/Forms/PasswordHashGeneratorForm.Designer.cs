namespace HotelManagementSystem.Forms
{
    partial class PasswordHashGeneratorForm
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
            label1 = new Label();
            btnGenerateAndSave = new Button();
            label3 = new Label();
            label4 = new Label();
            txtUsername = new TextBox();
            cboRole = new ComboBox();
            label2 = new Label();
            txtPassword = new TextBox();
            cboEmployee = new ComboBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 201);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 0;
            label1.Text = "Пароль";
            // 
            // btnGenerateAndSave
            // 
            btnGenerateAndSave.Location = new Point(151, 281);
            btnGenerateAndSave.Name = "btnGenerateAndSave";
            btnGenerateAndSave.Size = new Size(99, 35);
            btnGenerateAndSave.TabIndex = 4;
            btnGenerateAndSave.Text = "Сохранить";
            btnGenerateAndSave.UseVisualStyleBackColor = true;
            btnGenerateAndSave.Click += BtnGenerateAndSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 93);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 5;
            label3.Text = "Логин";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 147);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 6;
            label4.Text = "Роль";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(97, 90);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(274, 27);
            txtUsername.TabIndex = 7;
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "Администратор", "Ресепшен", "Горничная", "Техник" });
            cboRole.Location = new Point(100, 144);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(271, 28);
            cboRole.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 9;
            label2.Text = "Сотрудник";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(100, 198);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(271, 27);
            txtPassword.TabIndex = 10;
            // 
            // cboEmployee
            // 
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(97, 36);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(274, 28);
            cboEmployee.TabIndex = 11;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(272, 281);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(99, 35);
            btnClose.TabIndex = 12;
            btnClose.Text = "Выйти";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // PasswordHashGeneratorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 340);
            Controls.Add(btnClose);
            Controls.Add(cboEmployee);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(cboRole);
            Controls.Add(txtUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnGenerateAndSave);
            Controls.Add(label1);
            Name = "PasswordHashGeneratorForm";
            Text = "Генератор хэшей";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGenerateAndSave;
        private Label label3;
        private Label label4;
        private TextBox txtUsername;
        private ComboBox cboRole;
        private Label label2;
        private TextBox txtPassword;
        private ComboBox cboEmployee;
        private Button btnClose;
    }
}