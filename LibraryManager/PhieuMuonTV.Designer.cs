namespace LibraryManager
{
    partial class PhieuMuonTV
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
            label1 = new Label();
            panel1 = new Panel();
            tboxsearch = new TextBox();
            btnsearch = new Button();
            label3 = new Label();
            label15 = new Label();
            tboxto = new TextBox();
            tboxfrom = new TextBox();
            btnfilter = new Button();
            label11 = new Label();
            cboboxfilter = new ComboBox();
            dataGridView1 = new DataGridView();
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
            label1.Location = new Point(17, 10);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(213, 32);
            label1.TabIndex = 1;
            label1.Text = "Lịch Sử Mượn Trả";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-3, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(804, 57);
            panel1.TabIndex = 2;
            // 
            // tboxsearch
            // 
            tboxsearch.Font = new Font("Segoe UI", 14F);
            tboxsearch.ForeColor = Color.Black;
            tboxsearch.Location = new Point(14, 73);
            tboxsearch.Margin = new Padding(5);
            tboxsearch.Multiline = true;
            tboxsearch.Name = "tboxsearch";
            tboxsearch.Size = new Size(620, 37);
            tboxsearch.TabIndex = 3;
            // 
            // btnsearch
            // 
            btnsearch.BackColor = Color.MediumSeaGreen;
            btnsearch.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsearch.ForeColor = SystemColors.ButtonFace;
            btnsearch.Location = new Point(659, 73);
            btnsearch.Margin = new Padding(5);
            btnsearch.Name = "btnsearch";
            btnsearch.Size = new Size(117, 37);
            btnsearch.TabIndex = 25;
            btnsearch.Text = "Tìm kiếm";
            btnsearch.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label3.Location = new Point(493, 134);
            label3.Name = "label3";
            label3.Size = new Size(53, 25);
            label3.TabIndex = 32;
            label3.Text = "Đến:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label15.Location = new Point(224, 134);
            label15.Name = "label15";
            label15.Size = new Size(128, 25);
            label15.TabIndex = 31;
            label15.Text = "Tổng tiền từ:";
            // 
            // tboxto
            // 
            tboxto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            tboxto.Location = new Point(552, 131);
            tboxto.Name = "tboxto";
            tboxto.Size = new Size(100, 33);
            tboxto.TabIndex = 30;
            // 
            // tboxfrom
            // 
            tboxfrom.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            tboxfrom.Location = new Point(367, 131);
            tboxfrom.Name = "tboxfrom";
            tboxfrom.Size = new Size(100, 33);
            tboxfrom.TabIndex = 29;
            // 
            // btnfilter
            // 
            btnfilter.BackColor = Color.Lime;
            btnfilter.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnfilter.Location = new Point(694, 131);
            btnfilter.Name = "btnfilter";
            btnfilter.Size = new Size(82, 33);
            btnfilter.TabIndex = 28;
            btnfilter.Text = "Lọc";
            btnfilter.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label11.Location = new Point(14, 134);
            label11.Name = "label11";
            label11.Size = new Size(48, 25);
            label11.TabIndex = 27;
            label11.Text = "Lọc:";
            // 
            // cboboxfilter
            // 
            cboboxfilter.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            cboboxfilter.FormattingEnabled = true;
            cboboxfilter.Location = new Point(78, 131);
            cboboxfilter.Name = "cboboxfilter";
            cboboxfilter.Size = new Size(124, 33);
            cboboxfilter.TabIndex = 26;
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
            dataGridView1.Location = new Point(14, 212);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(762, 226);
            dataGridView1.TabIndex = 34;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkBlue;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(14, 173);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(762, 42);
            panel2.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 17.25F, FontStyle.Bold);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(209, 4);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(265, 31);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Phiếu Mượn";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PhieuMuonTV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(label15);
            Controls.Add(tboxto);
            Controls.Add(tboxfrom);
            Controls.Add(btnfilter);
            Controls.Add(label11);
            Controls.Add(cboboxfilter);
            Controls.Add(btnsearch);
            Controls.Add(tboxsearch);
            Controls.Add(panel1);
            Name = "PhieuMuonTV";
            Text = "Form1";
            Load += PhieuMuonTV_Load_1;
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
        private Panel panel1;
        private TextBox tboxsearch;
        private Button btnsearch;
        private Label label3;
        private Label label15;
        private TextBox tboxto;
        private TextBox tboxfrom;
        private Button btnfilter;
        private Label label11;
        private ComboBox cboboxfilter;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Label label2;
    }
}