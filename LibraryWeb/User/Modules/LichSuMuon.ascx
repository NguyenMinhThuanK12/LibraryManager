<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichSuMuon.ascx.cs" Inherits="LibraryWeb.User.Modules.LichSu" %>

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
tr:hover {
    background-color: #f0f9ff;
    cursor: pointer;
}
.selected-row {
    background-color: #d2f4dd !important;
}
.scrollable-table {
    max-height: 500px; 
    overflow-y: auto;
    border: 1px solid #ddd;
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
.total-amount {
    margin-top: 10px;
    font-weight: bold;
    color: #2e7d32;
}
.content-wrapper {
    display: flex;
    gap: 20px;
}
</style>

<div class="history-wrapper">
    <div class="tab-header">Lịch sử phiếu mượn</div>

    <div class="content-wrapper">
        <div class="left-pane">
            <div class="search-group">
                <asp:TextBox ID="txtSearchPM" runat="server" AutoPostBack="true" OnTextChanged="txtSearchPM_TextChanged" Placeholder="🔍 Tìm kiếm theo ID phiếu mượn" />
                <asp:DropDownList ID="ddlTrangThaiPM" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTrangThaiPM_SelectedIndexChanged">
                    <asp:ListItem Text="Tất cả" Value="" />
                    <asp:ListItem Text="Đang mượn" Value="Đang mượn" />
                    <asp:ListItem Text="Đã trả" Value="Đã trả" />
                    <asp:ListItem Text="Quá hạn" Value="Quá hạn" />
                </asp:DropDownList>
            </div>
            <div class="scrollable-table">
            <asp:Repeater ID="rptPhieuMuonList" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Mã phiếu</th>
                            <th>Ngày mượn</th>
                            <th>Hạn trả</th>
                            <th>Thời gian trả</th>
                            <th>Tổng tiền</th>
                            <th>Trạng thái</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                       <tr onclick="selectPhieuMuon('<%# Eval("MaPhieuMuon") %>', this)">
                            <td><%# Eval("MaPhieuMuon") %></td>
                            <td><%# Eval("NgayMuon") %></td>
                            <td><%# Eval("HanTra") %></td>
                            <td><%# Eval("ThoiGianTraThucTe") %></td>
                            <td><%# Eval("TongTien") %></td>
                            <td><%# Eval("TrangThaiMuon") %></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            </div>

        </div>

        <div class="right-pane">
            <div class="detail-title">Chi tiết phiếu mượn</div>
            <div class="detail-date">Ngày tạo: <asp:Label ID="lblNgayTao" runat="server" /></div>

            <asp:Repeater ID="rptChiTietPhieuMuon" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>STT</th>
                            <th>Tên thiết bị</th>
                            <th>Số lượng</th>
                            <th>Giá mượn</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %></td>
                            <td><%# Eval("TenSanPham") %></td>
                            <td><%# Eval("SoLuong") %></td>
                            <td><%# Eval("GiaMuon") %></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <div class="total-amount">Tổng tiền: <asp:Label ID="lblTongTienChiTiet" runat="server" /></div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function selectPhieuMuon(maPhieu, row) {
        // Bỏ class selected-row ở các dòng khác
        document.querySelectorAll("tr.selected-row").forEach(r => r.classList.remove("selected-row"));
        // Thêm class vào dòng hiện tại
        row.classList.add("selected-row");
        // Gọi postback
        __doPostBack('SelectPhieuMuon', maPhieu);
    }
</script>
