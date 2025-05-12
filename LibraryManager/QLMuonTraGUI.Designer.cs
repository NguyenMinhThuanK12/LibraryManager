using LibraryManager.ConnectDatabase;
using System.Data;

namespace muon
{
    partial class QLMuonTraGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            tboxsearch = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            btnsearch = new Button();
            label3 = new Label();
            label15 = new Label();
            tboxto = new TextBox();
            tboxfrom = new TextBox();
            btnfilter = new Button();
            dataGridView1 = new DataGridView();
            label11 = new Label();
            cboboxfilter = new ComboBox();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(36, 26);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(394, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Mượn Trả Thiết Bị";
            label1.Click += label1_Click;
            // 
            // tboxsearch
            // 
            tboxsearch.Font = new Font("Segoe UI", 14F);
            tboxsearch.ForeColor = Color.Black;
            tboxsearch.Location = new Point(35, 19);
            tboxsearch.Margin = new Padding(5);
            tboxsearch.Multiline = true;
            tboxsearch.Name = "tboxsearch";
            tboxsearch.Size = new Size(1015, 37);
            tboxsearch.TabIndex = 1;
            tboxsearch.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(85, 83);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(239, 55);
            button1.TabIndex = 2;
            button1.Text = "Thêm phiếu mượn";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnsearch);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(tboxto);
            panel1.Controls.Add(tboxfrom);
            panel1.Controls.Add(btnfilter);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(cboboxfilter);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(tboxsearch);
            panel1.Location = new Point(-1, 83);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1300, 1099);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // btnsearch
            // 
            btnsearch.BackColor = Color.MediumSeaGreen;
            btnsearch.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsearch.ForeColor = SystemColors.ButtonFace;
            btnsearch.Location = new Point(1056, 15);
            btnsearch.Margin = new Padding(5);
            btnsearch.Name = "btnsearch";
            btnsearch.Size = new Size(175, 47);
            btnsearch.TabIndex = 24;
            btnsearch.Text = "Tìm kiếm";
            btnsearch.UseVisualStyleBackColor = false;
            btnsearch.Click += btnsearch_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(831, 97);
            label3.Name = "label3";
            label3.Size = new Size(67, 32);
            label3.TabIndex = 23;
            label3.Text = "Đến:";
            label3.Click += label3_Click_1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(562, 97);
            label15.Name = "label15";
            label15.Size = new Size(163, 32);
            label15.TabIndex = 22;
            label15.Text = "Tổng tiền từ:";
            label15.Click += label15_Click;
            // 
            // tboxto
            // 
            tboxto.Location = new Point(890, 94);
            tboxto.Name = "tboxto";
            tboxto.Size = new Size(100, 39);
            tboxto.TabIndex = 18;
            // 
            // tboxfrom
            // 
            tboxfrom.Location = new Point(705, 94);
            tboxfrom.Name = "tboxfrom";
            tboxfrom.Size = new Size(100, 39);
            tboxfrom.TabIndex = 17;
            tboxfrom.TextChanged += textBox2_TextChanged;
            // 
            // btnfilter
            // 
            btnfilter.BackColor = Color.Lime;
            btnfilter.Location = new Point(1056, 97);
            btnfilter.Name = "btnfilter";
            btnfilter.Size = new Size(88, 41);
            btnfilter.TabIndex = 16;
            btnfilter.Text = "Lọc";
            btnfilter.UseVisualStyleBackColor = false;
            btnfilter.Click += btnfilter_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(38, 207);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1197, 381);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(352, 97);
            label11.Name = "label11";
            label11.Size = new Size(60, 32);
            label11.TabIndex = 9;
            label11.Text = "Lọc:";
            // 
            // cboboxfilter
            // 
            cboboxfilter.FormattingEnabled = true;
            cboboxfilter.Location = new Point(416, 94);
            cboboxfilter.Name = "cboboxfilter";
            cboboxfilter.Size = new Size(124, 40);
            cboboxfilter.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1560, 175);
            comboBox1.Margin = new Padding(5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(279, 36);
            comboBox1.TabIndex = 7;
            comboBox1.Text = "Lọc theo";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkBlue;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(38, 168);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1197, 42);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 17.25F, FontStyle.Bold);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(475, -1);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(336, 40);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Phiếu Mượn";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QLMuonTraGUI
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "QLMuonTraGUI";
            RightToLeft = RightToLeft.No;
            Size = new Size(1284, 711);
            Load += QLMuonTraGUI_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tboxsearch;
        private Button button1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label10;
        private Label label9;
        private Label label8;
        private ComboBox comboBox1;
        private Label label11;
        private ComboBox cboboxfilter;
        private DataGridView dataGridView1;
        private Button btnfilter;
        private TextBox tboxto;
        private TextBox tboxfrom;
        private Label label15;
        private Button btnsearch;
    }
}
