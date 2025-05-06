<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaNhan.ascx.cs" Inherits="LibraryWeb.User.Modules.CaNhan" %>

<style>
   .profile-wrapper {
    display: flex;
    gap: 30px;
    box-sizing: border-box;
    overflow: hidden;
}

.profile-section {
    flex: 1;
    background-color: #fff;
    border-radius: 10px;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0,0,0,0.1);
    display: flex;
    flex-direction: column;
    overflow-y: auto;
    max-height: calc(100vh - 100px); /* 60 topbar + 40 extra padding */
}

.profile-title {
    font-size: 22px;
    font-weight: bold;
    margin-bottom: 15px;
    text-align: center;
}

.form-group {
    margin-bottom: 10px;
}

.form-label {
    font-weight: bold;
    display: block;
    margin-bottom: 5px;
}

.form-control {
    width: 100%;
    padding: 7px 10px;
    border: 1px solid #ccc;
    border-radius: 6px;
    font-size: 14px;
}

.btn-group {
    margin-top: 20px;
    display: flex;
    justify-content: flex-end;
    gap: 10px;
}

.btn-save {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 10px 16px;
    border-radius: 5px;
    font-weight: bold;
    cursor: pointer;
}

.btn-save:hover {
    background-color: #0056b3;
}

.notification {
    color: green;
    font-weight: bold;
    margin-bottom: 10px;
    text-align: center;
}
</style>

<div class="profile-wrapper">
    <!-- Thông tin thành viên -->
    <div class="profile-section">
        <div class="profile-title">👤 Thông tin thành viên</div>
        <asp:Label ID="lblThongBao" runat="server" CssClass="notification" />

        <div class="form-group">
            <label class="form-label">Mã thành viên:</label>
            <asp:TextBox ID="txtMaThanhVien" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <div class="form-group">
            <label class="form-label">Họ tên:</label>
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <div class="form-group">
            <label class="form-label">Ngày sinh:</label>
            <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <div class="form-group">
            <label class="form-label">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label class="form-label">Số điện thoại:</label>
            <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label class="form-label">Địa chỉ:</label>
            <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" />
        </div>

        <div class="btn-group">
            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" CssClass="btn-save" OnClick="btnCapNhat_Click" />
        </div>
    </div>

    <!-- Thông tin tài khoản -->
    <div class="profile-section">
        <div class="profile-title">🔐 Tài khoản</div>

        <div class="form-group">
            <label class="form-label">Tên tài khoản:</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <asp:HiddenField ID="hdnMatKhau" runat="server" />

        <div class="form-group">
            <label class="form-label">Mật khẩu hiện tại:</label>
            <asp:TextBox ID="txtMatKhauCu" runat="server" TextMode="Password" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label class="form-label">Mật khẩu mới:</label>
            <asp:TextBox ID="txtMatKhauMoi" runat="server" TextMode="Password" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label class="form-label">Xác nhận mật khẩu mới:</label>
            <asp:TextBox ID="txtXacNhanMatKhau" runat="server" TextMode="Password" CssClass="form-control" />
        </div>

        <div class="btn-group">
            <asp:Button ID="btnDoiMatKhau" runat="server" Text="Đổi mật khẩu" CssClass="btn-save" OnClick="btnDoiMatKhau_Click" />
        </div>
    </div>
</div>
