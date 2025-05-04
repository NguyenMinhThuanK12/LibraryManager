<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="LibraryWeb.User.DangNhap" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', sans-serif;
            background-color: #f5f5f5;
        }

        .login-wrapper {
            width: 930px;
            height: 575px;
            margin: 30px auto;
            display: flex;
            box-shadow: 0 0 20px rgba(0,0,0,0.1);
            border-radius: 10px;
            overflow: hidden;
        }

        .left-panel {
            width: 400px;
            background-color: white;
            padding: 30px;
            position: relative;
        }

        .left-panel img.logo {
            width: 100px;
            margin: 30px auto;
            display: block;
        }

        .left-panel h2 {
            text-align: center;
            margin-top: 10px;
             margin-bottom: 50px;
            font-weight: bold;
        }

        .form-group input {
            width: 100%;
            border: none;
            border-bottom: 2px solid black;
            margin: 20px 0;
            padding: 10px 5px;
            font-size: 16px;
        }

        .form-group input:focus {
            outline: none;
        }

        .forgot {
            font-size: 14px;
            color: black;
            margin-bottom: 20px;
        }

        .btn-login {
            background-color: black;
            color: white;
            width: 100%;
            padding: 12px;
             margin-top: 50px;
            font-weight: bold;
            font-size: 16px;
            border: none;
        }

        .btn-login:hover {
            opacity: 0.9;
        }

        .close-btn {
            position: absolute;
            top: 10px;
            left: 10px;
            cursor: pointer;
            width: 30px;
        }

        .right-panel {
            flex: 1;
            background-color: black;
            color: white;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            position: relative;
        }

        .right-panel img {
            width: 260px; /* tăng từ 300px lên 360px */
            margin-top: -40px; /* dịch ảnh lên trên */
        }

        .right-panel h1 {
            font-size: 40px;
            margin-top: 0px;
            margin-bottom: 30px; /* thêm khoảng cách với nút đăng ký */
        }
        .register-section {
            position: absolute;
            bottom: 30px;
            text-align: center;
        }

        .register-section p {
            margin-bottom: 10px;
        }

        .btn-register {
            background-color: transparent;
            border: 2px solid white;
            color: white;
            padding: 8px 20px;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-register:hover {
            background-color: white;
            color: black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-wrapper">
            <!-- Left -->
            <div class="left-panel">
                <img class="close-btn" src="../Content/cancel.png" alt="Đóng" />
                <img class="logo" src="../Content/logo.png" alt="Logo" />
                <h2>Chào mừng trở lại !!</h2>

                <div class="form-group">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Tên đăng nhập" />
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Mật khẩu" />
                </div>
                <div class="forgot">Quên mật khẩu?</div>
                <asp:Button ID="btnLogin" runat="server" CssClass="btn-login" Text="Đăng nhập" OnClick="btnLogin_Click" />
            </div>

            <!-- Right -->
            <div class="right-panel">
                <img src="../Content/booklogo.png" alt="Book" />
                <h1>Library Management</h1>
                <div class="register-section">
                    <p>Bạn chưa có tài khoản? Đăng ký ngay bây giờ</p>
                    <asp:Button ID="btnRegister" runat="server" CssClass="btn-register" Text="Đăng ký" OnClick="btnRegister_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
