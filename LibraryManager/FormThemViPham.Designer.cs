namespace MinhViLap05
{
    partial class FormThemViPham
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
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            button1 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(188, 9);
            label1.Name = "label1";
            label1.Size = new Size(209, 38);
            label1.TabIndex = 0;
            label1.Text = "Thêm Vi Phạm";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.ItemHeight = 20;
            comboBox1.Location = new Point(173, 64);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(390, 28);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(117, 28);
            label2.TabIndex = 2;
            label2.Text = "Thành Viên :";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 130);
            label3.Name = "label3";
            label3.Size = new Size(133, 28);
            label3.TabIndex = 3;
            label3.Text = "Loại Vi Phạm :";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 199);
            label4.Name = "label4";
            label4.Size = new Size(75, 28);
            label4.TabIndex = 4;
            label4.Text = "Giá Trị :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 273);
            label5.Name = "label5";
            label5.Size = new Size(155, 28);
            label5.TabIndex = 5;
            label5.Text = "Bồi Thường (%) :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 344);
            label6.Name = "label6";
            label6.Size = new Size(141, 28);
            label6.TabIndex = 6;
            label6.Text = "Tổng Giá Tiền :";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(173, 134);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(390, 28);
            comboBox2.TabIndex = 7;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(173, 203);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(390, 28);
            comboBox3.TabIndex = 8;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(173, 273);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(390, 28);
            comboBox4.TabIndex = 9;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(173, 348);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(390, 28);
            comboBox5.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(418, 431);
            button1.Name = "button1";
            button1.Size = new Size(145, 50);
            button1.TabIndex = 11;
            button1.Text = "Xác Nhận";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(248, 431);
            button3.Name = "button3";
            button3.Size = new Size(145, 50);
            button3.TabIndex = 13;
            button3.Text = "Hủy";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // FormThemViPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 517);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "FormThemViPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Vi Phạm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private Button button1;
        private Button button3;
    }
}