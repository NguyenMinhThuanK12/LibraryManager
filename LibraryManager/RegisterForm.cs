using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class RegisterForm : Form
    {
        //  bo tròn góc

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,      // x góc trái
            int nTopRect,       // y góc trên
            int nRightRect,     // x góc phải
            int nBottomRect,    // y góc dưới
            int nWidthEllipse,  // độ cong ngang
            int nHeightEllipse  // độ cong dọc
        );
        public RegisterForm()
        {
            //  Gọi hàm để bo góc form
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            InitializeComponent();
        }
    }
}
