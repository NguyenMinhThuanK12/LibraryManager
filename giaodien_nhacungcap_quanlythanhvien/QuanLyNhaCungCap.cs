namespace giaodien_nhacungcap_quanlythanhvien
{
    public partial class QuanLyNhaCungCap : Form
    {
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện click vào nội dung ô ở đây
            // Ví dụ, bạn có thể hiển thị một hộp thoại với giá trị của ô được click
            MessageBox.Show(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }
    }
}
