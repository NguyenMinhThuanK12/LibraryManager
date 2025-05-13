<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuenMatKhau.aspx.cs" Inherits="LibraryWeb.User.QuenMatKhau" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quên mật khẩu</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 400px; margin: 100px auto;">
            <h3>Quên mật khẩu</h3>

            <asp:Label ID="lblStep" runat="server" Text="Bước 1: Nhập Email đã đăng ký" Font-Bold="true" />

            <!-- Bước 1: Nhập Email -->
            <div id="step1" runat="server">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
                <br />
                <asp:Button ID="btnSendOTP" runat="server" Text="Gửi mã OTP" CssClass="btn btn-primary" OnClick="btnSendOTP_Click" />
            </div>

            <!-- Bước 2: Nhập OTP -->
            <div id="step2" runat="server" visible="false">
                <asp:TextBox ID="txtOTP" runat="server" CssClass="form-control" Placeholder="Nhập mã OTP" />
                <br />
                <asp:Button ID="btnVerifyOTP" runat="server" Text="Xác minh OTP" CssClass="btn btn-success" OnClick="btnVerifyOTP_Click" />
            </div>

           <!-- Bước 3: Đặt lại mật khẩu -->
            <div id="step3" runat="server" visible="false">
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Mật khẩu mới" Style="margin-bottom: 10px;" />
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Nhập lại mật khẩu" Style="margin-bottom: 15px;" />
                <asp:Button ID="btnResetPassword" runat="server" Text="Đặt lại mật khẩu" CssClass="btn btn-warning" OnClick="btnResetPassword_Click" />
                <br /><br />
                <asp:HyperLink ID="lnkBackToLogin" runat="server" NavigateUrl="~/User/DangNhap.aspx" CssClass="btn btn-secondary" Visible="true">
                    Quay lại trang đăng nhập
                </asp:HyperLink>
            </div>

            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
