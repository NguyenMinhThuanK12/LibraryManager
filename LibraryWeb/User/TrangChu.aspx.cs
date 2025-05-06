using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace LibraryWeb.User
{
    public partial class TrangChu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Luôn luôn load lại module hiện tại, không chỉ khi !IsPostBack
            LoadModule(ViewState["CurrentModule"]?.ToString() ?? "DatChoMuon.ascx");
        }

        protected void btnDatChoMuon_Click(object sender, EventArgs e)
        {
            ViewState["CurrentModule"] = "DatChoMuon.ascx";
            SetActiveButton(btnDatChoMuon);
            LoadModule("DatChoMuon.ascx");
        }

        protected void btnLichSu_Click(object sender, EventArgs e)
        {
            ViewState["CurrentModule"] = "LichSuMuon.ascx";
            SetActiveButton(btnLichSu);
            LoadModule("LichSuMuon.ascx");
        }

        protected void btnCaNhan_Click(object sender, EventArgs e)
        {
            ViewState["CurrentModule"] = "CaNhan.ascx";
            SetActiveButton(btnCaNhan);
            LoadModule("CaNhan.ascx");
        }
        protected void btnDatCho_Click(object sender, EventArgs e)
        {
            ViewState["CurrentModule"] = "LichSuDatCho.ascx";
            SetActiveButton(btnDatCho);
            LoadModule("LichSuDatCho.ascx");
        }

        protected void btnViPham_Click(object sender, EventArgs e)
        {
            ViewState["CurrentModule"] = "LichSuViPham.ascx";
            SetActiveButton(btnViPham);
            LoadModule("LichSuViPham.ascx");
        }
        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/User/DangNhap.aspx");
        }

        private void LoadModule(string controlPath)
        {
            ContentPlaceholder.Controls.Clear();
            Control control = LoadControl("~/User/Modules/" + controlPath);
            ContentPlaceholder.Controls.Add(control);
        }

        private void SetActiveButton(Button selectedBtn)
        {
            // Reset lại tất cả các nút sidebar
            foreach (Control ctl in sidebar.Controls)
            {
                if (ctl is Button btn && btn.CssClass.Contains("btn-sidebar"))
                {
                    btn.CssClass = "btn btn-sidebar"; // reset class
                }
            }

            // Gán class selected cho nút được chọn
            selectedBtn.CssClass += " selected";
        }
    }
}
