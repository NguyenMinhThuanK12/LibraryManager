namespace LibraryManager

{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        /// 

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Label lblTitleRight;
        private System.Windows.Forms.Label lblRegisterPrompt;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picBook;
        private System.Windows.Forms.PictureBox picClose;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelLeft = new Panel();
            underlinePass = new Panel();
            underlineUser = new Panel();
            picLogo = new PictureBox();
            lblWelcome = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblForgotPassword = new Label();
            btnLogin = new Button();
            panelRight = new Panel();
            picBook = new PictureBox();
            lblTitleRight = new Label();
            lblRegisterPrompt = new Label();
            btnRegister = new Button();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBook).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(underlinePass);
            panelLeft.Controls.Add(underlineUser);
            panelLeft.Controls.Add(picLogo);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Controls.Add(txtUsername);
            panelLeft.Controls.Add(txtPassword);
            panelLeft.Controls.Add(lblForgotPassword);
            panelLeft.Controls.Add(btnLogin);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(400, 575);
            panelLeft.TabIndex = 1;
            panelLeft.Paint += panelLeft_Paint;
            // 
            // underlinePass
            // 
            underlinePass.BackColor = Color.Black;
            underlinePass.Location = new Point(82, 370);
            underlinePass.Name = "underlinePass";
            underlinePass.Size = new Size(230, 2);
            underlinePass.TabIndex = 1;
            // 
            // underlineUser
            // 
            underlineUser.BackColor = Color.Black;
            underlineUser.Location = new Point(82, 304);
            underlineUser.Name = "underlineUser";
            underlineUser.Size = new Size(230, 2);
            underlineUser.TabIndex = 0;

            picClose = new PictureBox();
            picClose.Image = Properties.Resources.cancel;
            picClose.SizeMode = PictureBoxSizeMode.Zoom;
            picClose.Size = new Size(40, 40);
            picClose.Location = new Point(10, 10);
            picClose.Cursor = Cursors.Hand;
            picClose.Click += picClose_Click;
            panelLeft.Controls.Add(picClose);


            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.SvgjsG2242;
            picLogo.Location = new Point(130, 41);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(121, 103);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.Location = new Point(44, 167);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(302, 41);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Chào mừng trở lại !!";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(82, 273);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Tên đăng nhập";
            txtUsername.Size = new Size(230, 25);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(82, 339);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Mật khẩu";
            txtPassword.Size = new Size(230, 25);
            txtPassword.TabIndex = 3;
            // 
            // lblForgotPassword
            // 
            lblForgotPassword.AutoSize = true;
            lblForgotPassword.Font = new Font("Segoe UI", 11F);
            lblForgotPassword.ForeColor = Color.Black;
            lblForgotPassword.Location = new Point(82, 397);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(150, 25);
            lblForgotPassword.TabIndex = 4;
            lblForgotPassword.Text = "Quên mật khẩu?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(82, 457);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(230, 56);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // Bo góc tròn bằng Region
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 25, 25));
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.Black;
            panelRight.Controls.Add(picBook);
            panelRight.Controls.Add(lblTitleRight);
            panelRight.Controls.Add(lblRegisterPrompt);
            panelRight.Controls.Add(btnRegister);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(400, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(530, 575);
            panelRight.TabIndex = 0;
            // 
            // picBook
            // 
            picBook.Image = Properties.Resources.booklogo;
            picBook.Location = new Point(117, 12);
            picBook.Name = "picBook";
            picBook.Size = new Size(319, 307);
            picBook.SizeMode = PictureBoxSizeMode.Zoom;
            picBook.TabIndex = 0;
            picBook.TabStop = false;
            // 
            // lblTitleRight
            // 
            lblTitleRight.AutoSize = true;
            lblTitleRight.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitleRight.ForeColor = Color.White;
            lblTitleRight.Location = new Point(37, 312);
            lblTitleRight.Name = "lblTitleRight";
            lblTitleRight.Size = new Size(462, 60);
            lblTitleRight.TabIndex = 1;
            lblTitleRight.Text = "Library Management";
            // 
            // lblRegisterPrompt
            // 
            lblRegisterPrompt.AutoSize = true;
            lblRegisterPrompt.ForeColor = Color.White;
            lblRegisterPrompt.Location = new Point(117, 397);
            lblRegisterPrompt.Name = "lblRegisterPrompt";
            lblRegisterPrompt.Size = new Size(310, 20);
            lblRegisterPrompt.TabIndex = 2;
            lblRegisterPrompt.Text = "Bạn chưa có tài khoản? Đăng ký ngay bây giờ";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Black;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Font = new Font("Segoe UI", 13F, FontStyle.Underline | FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(207, 445);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(161, 56);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.FlatAppearance.MouseDownBackColor = Color.Black; //  không nháy khi bấm
            btnRegister.FlatAppearance.MouseOverBackColor = Color.Black; //  không đổi nền khi hover
            btnRegister.Cursor = Cursors.Hand; //  hiển thị bàn tay khi hover
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(930, 575);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin SignIn Form";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBook).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel underlineUser;
        private Panel underlinePass;
    }
}
