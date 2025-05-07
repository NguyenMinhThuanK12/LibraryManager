<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatChoMuon.ascx.cs" Inherits="LibraryWeb.User.Modules.DatChoMuon" %>

<style>
    .content-body {
        height: calc(100vh - 80px);
        display: flex;
        gap: 20px;
        padding: 20px;
        box-sizing: border-box;
    }

    .device-list, .reservation-form {
        flex: 1;
        background-color: #fff;
        border-radius: 10px;
        padding: 20px;
        overflow-y: auto;
    }

    .search-bar {
        display: flex;
        gap: 10px;
        margin-bottom: 15px;
    }

    .search-box {
        flex: 3;
        min-width: 240px;
    }

    .dropdown-theloai {
        flex: 1;
        min-width: 120px;
    }

    .device-table, .reservation-table {
        width: 100%;
        border-collapse: collapse;
        text-align: left;
    }

    .device-table th, .device-table td,
    .reservation-table th, .reservation-table td {
        border: 1px solid #ccc;
        padding: 8px;
    }

    .device-table th, .reservation-table th {
        background-color: #f0f0f0;
    }

    .reservation-form h3 {
        text-align: center;
        font-weight: bold;
        margin-bottom: 20px;
    }

    .reservation-header {
        margin-bottom: 15px;
    }

    .btn-green {
        background-color: #28a745;
        color: white;
        font-weight: bold;
        border: none;
        padding: 10px 20px;
        border-radius: 6px;
        margin-top: 15px;
    }

    .link-delete {
        color: #007bff;
        cursor: pointer;
    }

    .link-delete:hover {
        text-decoration: underline;
    }
</style>

<div class="content-body">
    <!-- Danh sách thiết bị -->
    <div class="device-list">
        <div class="search-bar">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control search-box"
                placeholder="🔍 Tìm kiếm theo id hoặc tên thiết bị" AutoPostBack="true"
                OnTextChanged="txtSearch_TextChanged" />
            <asp:DropDownList ID="ddlTheLoai" runat="server" CssClass="form-control dropdown-theloai"
                AutoPostBack="true" OnSelectedIndexChanged="ddlTheLoai_SelectedIndexChanged" />
        </div>

        <asp:Repeater ID="rptThietBi" runat="server">
            <HeaderTemplate>
                <table class="device-table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Tên thiết bị</th>
                            <th>Thể loại</th>
                            <th>Vị trí</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("MaSanPham") %></td>
                    <td><%# Eval("TenSanPham") %></td>
                    <td><%# Eval("TenTL") %></td>
                    <td><%# Eval("ViTri") %></td>
                    <td>
                        <asp:LinkButton ID="btnChon" runat="server" CommandArgument='<%# Eval("MaSanPham") + "|" + Eval("TenSanPham") %>' OnCommand="btnChon_Command">Chọn</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <!-- Phiếu đặt chỗ -->
    <div class="reservation-form">
        <h3>📄 Phiếu đặt chỗ</h3>
        <div class="reservation-header">
            <p><strong>Thành viên:</strong> <%= Session["TenThanhVien"] != null ? Session["TenThanhVien"].ToString() : "Không rõ" %> &nbsp;&nbsp;&nbsp;&nbsp;
               <strong>Ngày tạo:</strong> <%= DateTime.Now.ToString("dd/MM/yyyy") %></p>
            <p><strong>Thời gian mượn dự kiến:</strong>
                <asp:TextBox ID="txtNgayMuon" runat="server" CssClass="form-control" TextMode="Date" />
            </p>
        </div>

        <asp:Repeater ID="rptDatCho" runat="server" OnItemCommand="rptDatCho_ItemCommand">
    <HeaderTemplate>
        <table class="reservation-table">
            <thead>
                <tr>
                    <th>STT</th>
                    <th>Tên thiết bị</th>
                    <th>Số lượng mượn</th>
                    <th>Hành động</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Container.ItemIndex + 1 %></td>
            <td><%# Eval("TenSanPham") %></td>
            <td>
            <asp:TextBox ID="txtSoLuong" runat="server" CssClass="form-control" Text="1" />
            <asp:HiddenField ID="hidMaSP" runat="server" Value='<%# Eval("MaSanPham") %>' />
        </td>
            <td>
                <asp:LinkButton ID="btnXoa" runat="server" CommandName="Xoa" CommandArgument='<%# Eval("MaSanPham") %>' CssClass="link-delete">Xóa</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
            </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>

        <asp:Button ID="btnTaoPhieu" runat="server" CssClass="btn btn-green" Text='Tạo phiếu' OnClick="btnTaoPhieu_Click" />
    </div>
</div>
