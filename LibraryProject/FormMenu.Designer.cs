namespace LibraryProject
{
    partial class FormMenu
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
            panelTop = new Panel();
            lblUserName = new Label();
            btnLogout = new Button();
            panelButtons = new Panel();
            btnHistory = new Button();
            btnBooks = new Button();
            panelTop.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(0, 5, 0, 5);
            panelTop.Size = new Size(544, 40);
            panelTop.TabIndex = 0;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Location = new Point(349, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 19);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "label1";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(74, 111, 165);
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(394, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 30);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnHistory);
            panelButtons.Controls.Add(btnBooks);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(0, 40);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(544, 321);
            panelButtons.TabIndex = 1;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.AliceBlue;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Location = new Point(174, 172);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(197, 30);
            btnHistory.TabIndex = 7;
            btnHistory.Text = "История выдачи книг";
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += BtnHistory_Click;
            // 
            // btnBooks
            // 
            btnBooks.BackColor = Color.AliceBlue;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.Location = new Point(174, 118);
            btnBooks.Name = "btnBooks";
            btnBooks.Size = new Size(197, 30);
            btnBooks.TabIndex = 6;
            btnBooks.Text = "Книги";
            btnBooks.UseVisualStyleBackColor = false;
            btnBooks.Click += BtnBooks_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(544, 361);
            Controls.Add(panelButtons);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Меню";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblUserName;
        private Button btnLogout;
        private Panel panelButtons;
        private Button btnHistory;
        private Button btnBooks;
    }
}