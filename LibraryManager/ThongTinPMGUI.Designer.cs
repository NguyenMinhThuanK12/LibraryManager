namespace muon
{
    partial class ThongTinPMGUI
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            tboxtotal = new TextBox();
            tboxdayleft = new TextBox();
            tboxdaybor = new TextBox();
            tboxname = new TextBox();
            tboxid = new TextBox();
            label7 = new Label();
            label3 = new Label();
            label6 = new Label();
            btnreturn = new Button();
            btncancel = new Button();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(55, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(249, 33);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 4);
            label1.Name = "label1";
            label1.Size = new Size(213, 25);
            label1.TabIndex = 2;
            label1.Text = "Thông tin phiếu mượn";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(tboxtotal);
            panel2.Controls.Add(tboxdayleft);
            panel2.Controls.Add(tboxdaybor);
            panel2.Controls.Add(tboxname);
            panel2.Controls.Add(tboxid);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(btnreturn);
            panel2.Controls.Add(btncancel);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 394);
            panel2.TabIndex = 2;
            // 
            // tboxtotal
            // 
            tboxtotal.Font = new Font("Segoe UI", 12.25F);
            tboxtotal.Location = new Point(222, 338);
            tboxtotal.Name = "tboxtotal";
            tboxtotal.Size = new Size(133, 29);
            tboxtotal.TabIndex = 18;
            // 
            // tboxdayleft
            // 
            tboxdayleft.Font = new Font("Segoe UI", 14.25F);
            tboxdayleft.Location = new Point(541, 66);
            tboxdayleft.Name = "tboxdayleft";
            tboxdayleft.ReadOnly = true;
            tboxdayleft.Size = new Size(158, 33);
            tboxdayleft.TabIndex = 17;
            // 
            // tboxdaybor
            // 
            tboxdaybor.Font = new Font("Segoe UI", 14.25F);
            tboxdaybor.Location = new Point(185, 71);
            tboxdaybor.Name = "tboxdaybor";
            tboxdaybor.ReadOnly = true;
            tboxdaybor.Size = new Size(136, 33);
            tboxdaybor.TabIndex = 16;
            // 
            // tboxname
            // 
            tboxname.Font = new Font("Segoe UI", 14.25F);
            tboxname.Location = new Point(524, 24);
            tboxname.Name = "tboxname";
            tboxname.ReadOnly = true;
            tboxname.Size = new Size(175, 33);
            tboxname.TabIndex = 15;
            tboxname.TextChanged += tboxname_TextChanged;
            // 
            // tboxid
            // 
            tboxid.Font = new Font("Segoe UI", 14.25F);
            tboxid.Location = new Point(205, 21);
            tboxid.Name = "tboxid";
            tboxid.ReadOnly = true;
            tboxid.Size = new Size(87, 33);
            tboxid.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(360, 69);
            label7.Name = "label7";
            label7.Size = new Size(163, 25);
            label7.TabIndex = 11;
            label7.Text = "Thời gian còn lại:";
            label7.Click += label7_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(56, 74);
            label3.Name = "label3";
            label3.Size = new Size(123, 25);
            label3.TabIndex = 10;
            label3.Text = "Ngày mượn:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(360, 24);
            label6.Name = "label6";
            label6.Size = new Size(146, 25);
            label6.TabIndex = 9;
            label6.Text = "Tên thành viên:";
            // 
            // btnreturn
            // 
            btnreturn.BackColor = Color.Lime;
            btnreturn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnreturn.Location = new Point(604, 335);
            btnreturn.Name = "btnreturn";
            btnreturn.Size = new Size(95, 32);
            btnreturn.TabIndex = 8;
            btnreturn.Text = "Trả";
            btnreturn.UseVisualStyleBackColor = false;
            btnreturn.Click += btnreturn_Click;
            // 
            // btncancel
            // 
            btncancel.BackColor = Color.Red;
            btncancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncancel.Location = new Point(488, 334);
            btncancel.Name = "btncancel";
            btncancel.Size = new Size(95, 32);
            btncancel.TabIndex = 7;
            btncancel.Text = "Hủy";
            btncancel.UseVisualStyleBackColor = false;
            btncancel.Click += btncancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.25F, FontStyle.Bold);
            label4.Location = new Point(56, 341);
            label4.Name = "label4";
            label4.Size = new Size(160, 23);
            label4.TabIndex = 5;
            label4.Text = "Tổng tiền phải trả:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(640, 185);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 24);
            label2.Name = "label2";
            label2.Size = new Size(143, 25);
            label2.TabIndex = 0;
            label2.Text = "Mã thành viên:";
            label2.Click += label2_Click;
            // 
            // ThongTinPMGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aqua;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ThongTinPMGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin phiếu mượn";
            Load += ThongTinPMGUI_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnreturn;
        private Button btncancel;
        private Label label5;
        private Label label4;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private TextBox tboxid;
        private TextBox tboxtotal;
        private TextBox tboxdayleft;
        private TextBox tboxdaybor;
        private TextBox tboxname;
    }
}