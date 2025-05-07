<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichSuViPham.ascx.cs" Inherits="LibraryWeb.User.Modules.LichSuViPham" %>

<style>
    .tab-header {
        font-size: 20px;
        font-weight: bold;
        margin-bottom: 20px;
        color: #4CAF50;
    }

    .left-pane, .right-pane {
        min-height: 570px;
        background-color: white;
        border-radius: 10px;
        padding: 20px;
        box-shadow: 0 0 10px rgba(0,0,0,0.05);
    }

    .left-pane {
        flex: 1.2;
    }

    .right-pane {
        flex: 0.8;
        border-left: 2px solid #ddd;
    }

    .search-group {
        display: flex;
        gap: 10px;
        margin-bottom: 10px;
    }

    .search-group input[type="text"] {
        flex: 1;
    }

    .search-group input,
    .search-group select {
        padding: 6px 10px;
        font-size: 14px;
    }

    table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 10px;
    }

    th, td {
        border: 1px solid #ccc;
        padding: 8px;
        text-align: left;
    }

    th {
        background-color: #f2f2f2;
    }

    /* Hover and selected row effects */
    tr:hover {
        background-color: #f0f9ff;
        cursor: pointer;
    }

    .selected-row {
        background-color: #d2f4dd !important;
    }

    .detail-title {
        font-size: 20px;
        font-weight: bold;
        margin-bottom: 10px;
        text-align: center;
    }

    .detail-date {
        margin-bottom: 10px;
    }

    .content-wrapper {
        display: flex;
        gap: 20px;
    }
</style>

<div class="history-wrapper">
    <div class="tab-header">Lịch sử vi phạm</div>

    <div class="content-wrapper">
        <!-- LEFT PANEL -->
        <div class="left-pane">
            <div class="search-group">
                <asp:TextBox ID="txtSearchPhat" runat="server" AutoPostBack="true" OnTextChanged="txtSearchPhat_TextChanged" Placeholder="🔍 Tìm kiếm theo ID phiếu phạt" />
                <asp:DropDownList ID="ddlTrangThaiPhat" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTrangThaiPhat_SelectedIndexChanged">
                    <asp:ListItem Text="Tất cả" Value="" />
                    <asp:ListItem Text="Đã xử lý" Value="Đã xử lý" />
                    <asp:ListItem Text="Chưa xử lý" Value="Chưa xử lý" />
                </asp:DropDownList>
            </div>

            <asp:Repeater ID="rptPhieuPhat" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Mã phiếu</th>
                            <th>Mã phiếu mượn</th>
                            <th>Ngày tạo</th>
                            <th>Trạng thái</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr onclick="selectPhieuPhat('<%# Eval("MaPhieuPhat") %>', this)">
                            <td><%# Eval("MaPhieuPhat") %></td>
                            <td><%# Eval("MaPhieuMuon") %></td>
                            <td><%# Eval("NgayTao", "{0:dd/MM/yyyy HH:mm}") %></td>
                            <td><%# Eval("TrangThaiThanhToan") %></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <!-- RIGHT PANEL -->
        <div class="right-pane">
            <div class="detail-title">Chi tiết phiếu phạt</div>
            <div class="detail-date">Ngày tạo: <asp:Label ID="lblNgayTaoPhat" runat="server" /></div>
            <div class="detail-date">Trạng thái: <asp:Label ID="lblTrangThaiPhat" runat="server" /></div>

            <asp:Repeater ID="rptChiTietPhieuPhat" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>STT</th>
                            <th>Tên thiết bị</th>
                            <th>Tiền phạt</th>
                            <th>Loại phạt</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %></td>
                            <td><%# Eval("TenSanPham") %></td>
                            <td><%# Eval("TienPhat", "{0:N0} đ") %></td>
                            <td><%# Eval("LoaiPhat") %></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>

<script type="text/javascript">
    function selectPhieuPhat(maPhieu, row) {
        // Bỏ chọn các dòng trước
        document.querySelectorAll("tr.selected-row").forEach(r => r.classList.remove("selected-row"));
        // Thêm class cho dòng được chọn
        row.classList.add("selected-row");
        // Gọi hàm postback
        __doPostBack('SelectPhieuPhat', maPhieu);
    }
</script>
