<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="LibraryWeb.User.TrangChu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang chủ</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            margin: 0;
            font-family: 'Segoe UI', sans-serif;
        }
        .main-layout {
            display: flex;
            height: 100vh;
            overflow: hidden;
        }
        .sidebar {
            width: 210px;
            background-color: #fff;
            border-right: 1px solid #ccc;
            display: flex;
            flex-direction: column;
        }
        .sidebar .btn-sidebar {
            width: 90%;
            margin: 10px auto;
            padding: 12px;
            font-size: 15px;
            border-radius: 10px;
            border: none;
            background-color: white;
            color: black;
            text-align: left;
            transition: 0.2s;
        }
        .sidebar .btn-sidebar:hover {
            background-color: #f0f0f0;
        }
        .sidebar .btn-sidebar.selected {
            background-color: #34a853;
            color: white;
            font-weight: bold;
        }
        .topbar {
            height: 60px;
            background-color: #fff;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 0 20px;
            border-bottom: 1px solid #ccc;
        }
       .logo-section img {
            width: 32px;
            height: 32px;
            object-fit: contain;
            margin-right: 10px;
        }
       .sidebar-logo {
            height: 60px;
            display: flex;
            align-items: center;
            padding-left: 20px;
            border-bottom: 1px solid #ccc;
            margin-bottom: 15px;
            margin-top:0px;
            background-color: #fff;
        }
        .user-section {
            text-align: right;
        }
        .content {
            flex: 1;
            display: flex;
            flex-direction: column;
        }
        .content-body {
            flex: 1;
            padding: 20px;
            background-color: #f8f8f8;
        }
        .logout-btn {
            margin-top: auto !important;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="main-layout">
            <!-- Sidebar -->
            <div id="sidebar" runat="server" class="sidebar">
                <div class="logo-section sidebar-logo">
                    <img src="../Content/LogoApp.png" alt="Logo" />
                    <span style="font-size: 18px; font-weight: bold;">Library App</span>
                </div>
                <asp:Button ID="btnDatChoMuon" runat="server" Text="📅 Đặt chỗ mượn" OnClick="btnDatChoMuon_Click" CssClass="btn btn-sidebar" />
                <asp:Button ID="btnLichSu" runat="server" Text="📖 Phiếu mượn" OnClick="btnLichSu_Click" CssClass="btn btn-sidebar" />
                <asp:Button ID="btnDatCho" runat="server" Text="📘 Phiếu đặt chỗ" OnClick="btnDatCho_Click" CssClass="btn btn-sidebar" />
                <asp:Button ID="btnViPham" runat="server" Text="⚠️ Phiếu vi phạm" OnClick="btnViPham_Click" CssClass="btn btn-sidebar" />
                <asp:Button ID="btnCaNhan" runat="server" Text="👤 Cá nhân" OnClick="btnCaNhan_Click" CssClass="btn btn-sidebar" />
                <div style="flex-grow: 1;"></div>
                <asp:Button ID="btnDangXuat" runat="server" Text="🚪 Đăng xuất" OnClick="btnDangXuat_Click" CssClass="btn btn-sidebar logout-btn" />
            </div>

            <!-- Content -->
            <div class="content">
                <div class="topbar">
                     <div></div>
                    <div style="text-align: right;">
                        <strong><%= DateTime.Now.ToString("hh:mm tt") %></strong><br />
                        <small><%= DateTime.Now.ToString("'thg' M dd, yyyy") %></small>
                    </div>
                </div>
                <div class="content-body">
                    <asp:PlaceHolder ID="ContentPlaceholder" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
