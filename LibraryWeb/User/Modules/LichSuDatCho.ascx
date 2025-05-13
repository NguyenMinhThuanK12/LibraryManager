<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichSuDatCho.ascx.cs" Inherits="LibraryWeb.User.Modules.LichSuDatCho" %>

<style>
    
    .tab-header {
        font-size: 20px;
        font-weight: bold;
        margin-bottom: 20px;
        color: #4CAF50;
    }
    .content-wrapper {
        display: flex;
        gap: 20px;
    }
    .left-pane, .right-pane {
        background-color: white;
        border-radius: 10px;
        padding: 20px;
        box-shadow: 0 0 10px rgba(0,0,0,0.05);
        min-height: 570px;
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
    .scrollable-table {
    max-height: 500px; 
    overflow-y: auto;
    border: 1px solid #ddd;
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
</style>

<div class="history-wrapper">
    <div class="tab-header">Lịch sử đặt chỗ</div>

    <div class="content-wrapper">
        <!-- Bảng danh sách -->
        <div class="left-pane">
            <div class="search-group">
                <asp:TextBox ID="txtSearchDC" runat="server" AutoPostBack="true" OnTextChanged="txtSearchDC_TextChanged" Placeholder="🔍 Tìm kiếm theo ID phiếu đặt" />
                <asp:DropDownList ID="ddlTrangThaiDC" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTrangThaiDC_SelectedIndexChanged">
                    <asp:ListItem Text="Tất cả" Value="" />
                    <asp:ListItem Text="Đang xử lý" Value="Đang xử lý" />
                    <asp:ListItem Text="Đã xác nhận" Value="Đã xác nhận" />
                    <asp:ListItem Text="Đã huỷ" Value="Đã huỷ" />
                </asp:DropDownList>
            </div>
            <div class="scrollable-table">
            <asp:Repeater ID="rptPhieuDatCho" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Mã phiếu</th>
                            <th>Thời gian đặt</th>
                            <th>Thời gian mượn</th>
                            <th>Trạng thái</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                       <tr onclick="selectPhieuDatCho('<%# Eval("MaPhieu") %>', this)">
                            <td><%# Eval("MaPhieu") %></td>
                            <td><%# Eval("ThoiGianDat", "{0:dd/MM/yyyy HH:mm}") %></td>
                            <td><%# Eval("ThoiGianMuonDuKien", "{0:dd/MM/yyyy HH:mm}") %></td>
                            <td><%# Eval("TrangThaiDat") %></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            </div>
        </div>

        <!-- Chi tiết phiếu -->
        <div class="right-pane">
            <div class="detail-title">Chi tiết phiếu đặt chỗ</div>
            <div class="detail-date">Thời gian đặt: <asp:Label ID="lblThoiGianDat" runat="server" /></div>
            <div class="detail-date">Thời gian mượn: <asp:Label ID="lblThoiGianMuon" runat="server" /></div>
            <div class="detail-date">Trạng thái: <asp:Label ID="lblTrangThaiDat" runat="server" /></div>

            <asp:Repeater ID="rptChiTietPhieuDatCho" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>STT</th>
                            <th>Tên thiết bị</th>
                            <th>Số lượng</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %></td>
                            <td><%# Eval("TenSanPham") %></td>
                            <td><%# Eval("SoLuong") %></td>
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
    function selectPhieuDatCho(maPhieu, row) {
        // Xoá highlight trước đó
        document.querySelectorAll("tr.selected-row").forEach(tr => tr.classList.remove("selected-row"));
        // Highlight dòng mới
        row.classList.add("selected-row");
        // Gọi postback
        __doPostBack('SelectPhieuDatCho', maPhieu);
    }

</script>
