namespace LibraryManager
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelRight;  // Đổi từ panelLeft thành panelRight
        private System.Windows.Forms.Panel panelLeft;  // Đổi từ panelRight thành panelLeft
        private System.Windows.Forms.Label lblRegisterTitle;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtDob;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picBook;
        private System.Windows.Forms.Label lblTitleLeft;

        private System.Windows.Forms.Label lblRegisterPrompt;
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         
            panelRight = new System.Windows.Forms.Panel();
            picLogo = new PictureBox();
            lblRegisterTitle = new Label();
            txtFullName = new TextBox();
            txtDob = new TextBox();
            txtGender = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            btnLogin = new Button();
            panelLeft = new System.Windows.Forms.Panel();
            lblRegisterPrompt = new Label();
            lblTitleLeft = new Label();
            picBook = new PictureBox();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBook).BeginInit();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(picLogo);
            panelRight.Controls.Add(lblRegisterTitle);
            panelRight.Controls.Add(txtFullName);
            panelRight.Controls.Add(txtDob);
            panelRight.Controls.Add(txtGender);
            panelRight.Controls.Add(txtPhone);
            panelRight.Controls.Add(txtEmail);
            panelRight.Controls.Add(txtAddress);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(btnRegister);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(400, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(531, 575);
            panelRight.TabIndex = 1;
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.SvgjsG2242;
            picLogo.Location = new Point(197, 31);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(121, 103);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblRegisterTitle
            // 
            lblRegisterTitle.AutoSize = true;
            lblRegisterTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRegisterTitle.Location = new Point(134, 167);
            lblRegisterTitle.Name = "lblRegisterTitle";
            lblRegisterTitle.Size = new Size(274, 41);
            lblRegisterTitle.TabIndex = 1;
            lblRegisterTitle.Text = "Đăng ký tài khoản";
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.ForeColor = Color.Black;
            txtFullName.Location = new Point(41, 244);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Họ tên";
            txtFullName.Size = new Size(230, 25);
            txtFullName.TabIndex = 2;
            // 
            // txtDob
            // 
            txtDob.BorderStyle = BorderStyle.None;
            txtDob.Font = new Font("Segoe UI", 11F);
            txtDob.ForeColor = Color.Black;
            txtDob.Location = new Point(300, 244);
            txtDob.Name = "txtDob";
            txtDob.PlaceholderText = "Ngày sinh";
            txtDob.Size = new Size(230, 25);
            txtDob.TabIndex = 3;
            // 
            // txtGender
            // 
            txtGender.BorderStyle = BorderStyle.None;
            txtGender.Font = new Font("Segoe UI", 11F);
            txtGender.ForeColor = Color.Black;
            txtGender.Location = new Point(41, 301);
            txtGender.Name = "txtGender";
            txtGender.PlaceholderText = "Giới tính";
            txtGender.Size = new Size(230, 25);
            txtGender.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.Location = new Point(300, 301);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Số điện thoại";
            txtPhone.Size = new Size(230, 25);
            txtPhone.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(41, 357);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(230, 25);
            txtEmail.TabIndex = 6;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Font = new Font("Segoe UI", 11F);
            txtAddress.Location = new Point(300, 356);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Địa chỉ";
            txtAddress.Size = new Size(230, 25);
            txtAddress.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(41, 432);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(230, 25);
            txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(300, 432);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(230, 25);
            txtPassword.TabIndex = 9;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Black;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(134, 488);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(230, 56);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.Black;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold | FontStyle.Underline);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(105, 432);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(161, 56);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.Black;
            panelLeft.Controls.Add(lblRegisterPrompt);
            panelLeft.Controls.Add(lblTitleLeft);
            panelLeft.Controls.Add(picBook);
            panelLeft.Controls.Add(btnLogin);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(400, 575);
            panelLeft.TabIndex = 0;
            // 
            // lblRegisterPrompt
            // 
            lblRegisterPrompt.AutoSize = true;
            lblRegisterPrompt.ForeColor = Color.White;
            lblRegisterPrompt.Location = new Point(42, 397);
            lblRegisterPrompt.Name = "lblRegisterPrompt";
            lblRegisterPrompt.Size = new Size(314, 20);
            lblRegisterPrompt.TabIndex = 2;
            lblRegisterPrompt.Text = "Bạn đã có tài khoản? Đăng nhập ngay bây giờ";
            // 
            // lblTitleLeft
            // 
            lblTitleLeft.AutoSize = true;
            lblTitleLeft.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitleLeft.ForeColor = Color.White;
            lblTitleLeft.Location = new Point(30, 291);
            lblTitleLeft.Name = "lblTitleLeft";
            lblTitleLeft.Size = new Size(354, 46);
            lblTitleLeft.TabIndex = 1;
            lblTitleLeft.Text = "Library Management";
            // 
            // picBook
            // 
            picBook.Image = Properties.Resources.booklogo;
            picBook.Location = new Point(42, 12);
            picBook.Name = "picBook";
            picBook.Size = new Size(314, 276);
            picBook.SizeMode = PictureBoxSizeMode.Zoom;
            picBook.TabIndex = 0;
            picBook.TabStop = false;
            // 
            // RegisterForm
            // 
            this.ClientSize = new Size(930, 575);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Size = new Size(400, 575); // Fix size for left panel

            panelRight.Dock = DockStyle.Fill;
            panelRight.Size = new Size(530, 575); // Fix size for right panel
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register Form";
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBook).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
