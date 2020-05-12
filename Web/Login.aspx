
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Class_SQL.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>社区医疗服务系统</title>
    <meta name="viewport" content="width=device-width" />
    <%-- <link href="CSS/login.css" rel="stylesheet" type="text/css"/>--%>
    <script type="text/javascript" src="scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="js/layout.js"></script>
    <meta name="renderer" content="webkit|ie-comp|ie-stand" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="stylesheet" href="./css/font.css" />
    <link rel="stylesheet" href="./css/xadmin.css" />
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <%--<link rel="shortcut icon" href="favicon.ico"/>--%>
</head>

<body id="Body1" class="login-bg" runat="server">
    <div class="login layui-anim layui-anim-up">
        <div class="message">社区医疗服务系统</div>
        <div id="darkbannerwrap"></div>
        <form class="layui-form" id="form1" runat="server">
            <asp:TextBox ID="txt_Username" runat="server" class="text_value"></asp:TextBox>
            <hr class="hr15" />
            <asp:TextBox ID="txt_Password" runat="server" class="text_value" TextMode="Password"></asp:TextBox>
            <hr class="hr15" />
            <div class="layui-form">
                <asp:RadioButton ID="rb_OldPeople" runat="server" type="radio" lay-skin="primary" style="font-size: 16px" Text="养老人员" Checked="true" GroupName="people"/>
                <asp:RadioButton ID="rb_Doctor" runat="server" type="radio" lay-skin="primary" style="font-size: 16px" Text="医护人员" GroupName="people"/>
              </div>
                        <hr class="hr15" />
            <asp:Button ID="btnLogin" runat="server" class="button" OnClick="btnLogin_Click" Text="登录" />
            <hr class="hr20" />
            <asp:Button ID="btn_Register" runat="server" class="button" OnClick="btnRegister_Click" Text="注册" />
            <hr class="hr20" />
        </form>
    </div>
</body>
</html>
