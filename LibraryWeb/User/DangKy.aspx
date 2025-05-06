<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="LibraryWeb.User.DangKy" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', sans-serif;
            background-color: #f5f5f5;
        }

        .register-wrapper {
            width: 930px;
            height: 500px;
            margin: 30px auto;
            display: flex;
            box-shadow: 0 0 20px rgba(0,0,0,0.1);
            border-radius: 10px;
            overflow: hidden;
        }

        .left-panel {
            width: 400px;
            background-color: black;
            color: white;
            text-align: center;
            padding: 50px 30px;
        }

        .left-panel img {
            width: 180px;
            margin-bottom: 20px;
        }

        .left-panel h1 {
            font-size: 36px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .left-panel p {
            margin-bottom: 30px;
        }

        .btn-login {
            background-color: white;
            color: black;
            border: 2px solid white;
            padding: 8px 20px;
            font-size: 16px;
            font-weight: bold;
            border-radius: 5px;
        }

        .right-panel {
            flex: 1;
            background-color: white;
            padding: 30px;
        }

        .right-panel h2 {
            text-align: center;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .form-row {
            display: flex;
            gap: 10px;
            margin-bottom: 15px
        }

        .form-row .form-group {
            flex: 1;
        }

        .form-group input {
            width: 100%;
            border: 1px solid #ccc;
            padding: 8px 10px;
            margin-bottom: 15px;
            font-size: 14px;
        }

        .btn-register {
            background-color: black;
            color: white;
            padding: 10px 20px;
            font-size: 16px;
            font-weight: bold;
            border: none;
            width: 100%;
            border-radius: 5px;
            margin-top: 40px;
        }

        .btn-register:hover {
            background-color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-wrapper">
            <!-- Left panel -->
            <div class="left-panel">
                <img src="../Content/booklogo.png" alt="Logo" />
                <h1>Library Management</h1>
                <p>Bạn đã có tài khoản? Đăng nhập ngay bây giờ</p>
                <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="btn-login" OnClick="btnLogin_Click" />
            </div>

            <!-- Right panel -->
            <div class="right-panel">
                <h2>Đăng ký</h2>
                <div class="form-row">
                    <div class="form-group">
                        <asp:TextBox ID="txtHoTen" runat="server" placeholder="Họ tên" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtNgaySinh" runat="server" TextMode="Date" placeholder="Ngày sinh" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-row">
                   
                    <div class="form-group">
                        <asp:TextBox ID="txtSoDienThoai" runat="server" placeholder="Số điện thoại" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtDiaChi" runat="server" placeholder="Địa chỉ" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group">
                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control" />
                    </div>
                </div>

                <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" CssClass="btn-register" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>
