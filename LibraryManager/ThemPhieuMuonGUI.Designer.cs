namespace muon
{
    partial class ThemPhieuMuonGUI
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            tboxquantity = new TextBox();
            label5 = new Label();
            btnadditem = new Button();
            tboxmoney = new TextBox();
            btnadd = new Button();
            btncancel = new Button();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            cboboxitem = new ComboBox();
            cboboxuser = new ComboBox();
            label3 = new Label();
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
            panel1.Size = new Size(200, 33);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 4);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 2;
            label1.Text = "Thêm phiếu mượn";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(tboxquantity);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnadditem);
            panel2.Controls.Add(tboxmoney);
            panel2.Controls.Add(btnadd);
            panel2.Controls.Add(btncancel);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(cboboxitem);
            panel2.Controls.Add(cboboxuser);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 394);
            panel2.TabIndex = 1;
            // 
            // tboxquantity
            // 
            tboxquantity.Font = new Font("Segoe UI", 14F);
            tboxquantity.Location = new Point(598, 39);
            tboxquantity.Name = "tboxquantity";
            tboxquantity.Size = new Size(97, 32);
            tboxquantity.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(493, 42);
            label5.Name = "label5";
            label5.Size = new Size(99, 25);
            label5.TabIndex = 11;
            label5.Text = "Số lượng:";
            // 
            // btnadditem
            // 
            btnadditem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnadditem.Location = new Point(511, 87);
            btnadditem.Name = "btnadditem";
            btnadditem.Size = new Size(145, 30);
            btnadditem.TabIndex = 10;
            btnadditem.Text = "Thêm thiết bị";
            btnadditem.UseVisualStyleBackColor = true;
            btnadditem.Click += btnadditem_Click;
            // 
            // tboxmoney
            // 
            tboxmoney.Font = new Font("Segoe UI", 14F);
            tboxmoney.Location = new Point(207, 335);
            tboxmoney.Name = "tboxmoney";
            tboxmoney.Size = new Size(100, 32);
            tboxmoney.TabIndex = 9;
            // 
            // btnadd
            // 
            btnadd.BackColor = Color.Lime;
            btnadd.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnadd.Location = new Point(643, 334);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(95, 32);
            btnadd.TabIndex = 8;
            btnadd.Text = "Thêm";
            btnadd.UseVisualStyleBackColor = false;
            btnadd.Click += btnadd_Click;
            // 
            // btncancel
            // 
            btncancel.BackColor = Color.Red;
            btncancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncancel.Location = new Point(520, 334);
            btncancel.Name = "btncancel";
            btncancel.Size = new Size(95, 32);
            btncancel.TabIndex = 7;
            btncancel.Text = "Hủy bỏ";
            btncancel.UseVisualStyleBackColor = false;
            btncancel.Click += btncancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.25F, FontStyle.Bold);
            label4.Location = new Point(56, 341);
            label4.Name = "label4";
            label4.Size = new Size(145, 23);
            label4.TabIndex = 5;
            label4.Text = "Tổng tiền mượn:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(149, 136);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(466, 169);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // cboboxitem
            // 
            cboboxitem.Font = new Font("Segoe UI", 14F);
            cboboxitem.FormattingEnabled = true;
            cboboxitem.Location = new Point(182, 84);
            cboboxitem.Name = "cboboxitem";
            cboboxitem.Size = new Size(264, 33);
            cboboxitem.TabIndex = 3;
            // 
            // cboboxuser
            // 
            cboboxuser.Font = new Font("Segoe UI", 14F);
            cboboxuser.FormattingEnabled = true;
            cboboxuser.Location = new Point(195, 38);
            cboboxuser.Name = "cboboxuser";
            cboboxuser.Size = new Size(214, 33);
            cboboxuser.TabIndex = 2;
            cboboxuser.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(43, 87);
            label3.Name = "label3";
            label3.Size = new Size(133, 25);
            label3.TabIndex = 1;
            label3.Text = "Thêm thiết bị:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 41);
            label2.Name = "label2";
            label2.Size = new Size(146, 25);
            label2.TabIndex = 0;
            label2.Text = "Tên thành viên:";
            label2.Click += label2_Click;
            // 
            // ThemPhieuMuonGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aqua;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ThemPhieuMuonGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm phiếu mượn";
            Load += ThemPhieuMuonGUI_Load;
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
        private Label label3;
        private Label label2;
        private ComboBox cboboxuser;
        private ComboBox cboboxitem;
        private Label label4;
        private DataGridView dataGridView1;
        private Button btnadd;
        private Button btncancel;
        private Button btnadditem;
        private TextBox tboxmoney;
        private Label label5;
        private TextBox tboxquantity;
    }
}