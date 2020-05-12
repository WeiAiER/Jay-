<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Class_SQL.Web.Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>社区医疗服务系统</title>
    <meta name="description" content="AppUI - Admin Dashboard Template & UI Framework" />
    <meta name="author" content="rustheme" />
    <meta name="robots" content="noindex, nofollow" />
    <link rel="apple-touch-icon" href="assets/img/favicons/apple-touch-icon.png" />
    <link rel="icon" href="assets/img/favicons/favicon.ico" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:300,400,400italic,500,900%7CRoboto+Slab:300,400%7CRoboto+Mono:400" />
    <link rel="stylesheet" id="css-font-awesome" href="assets/css/font-awesome.css" />
    <link rel="stylesheet" id="css-ionicons" href="assets/css/ionicons.css" />
    <link rel="stylesheet" id="css-bootstrap" href="assets/css/bootstrap.css" />
    <link rel="stylesheet" id="css-app" href="assets/css/app.css" />
    <link rel="stylesheet" id="css-app-custom" href="assets/css/app-custom.css" />
</head>
<body class="app-ui layout-has-drawer layout-has-fixed-header">
    <div class="app-layout-canvas">
        <div class="app-layout-container">
            <!-- Drawer -->
            <aside class="app-layout-drawer">
                <!-- Drawer scroll area -->
                <div class="app-layout-drawer-scroll">
                    <!-- Drawer logo -->
                    <div id="logo" class="drawer-header">
                        <a href="Index.aspx">
                            <img class="img-responsive" src="assets/img/logo/logo-backend.png" title="AppUI" alt="AppUI" /></a>
                    </div>
                    <!-- Drawer navigation -->
                    <nav class="drawer-main">
                        <ul class="nav nav-drawer">
                            <li class="nav-item nav-drawer-header">menu</li>
                            <li class="nav-item nav-item-has-subnav">
                                <a href="javascript:void(0)"><i class="ion-ios-calculator-outline"></i>个人信息</a>
                                <ul class="nav nav-subnav">
                                    <li id="old1" runat="server">
                                        <a href="OldMan.aspx">养老人员信息</a>
                                    </li>
                                    <li id="menu1" runat="server">
                                        <a href="Doctor.aspx">医护人员信息</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="nav-item nav-item-has-subnav">
                                <a href="javascript:void(0)"><i class="ion-ios-calculator-outline"></i>健康监督</a>
                                <ul class="nav nav-subnav">
                                    <li id="old2" runat="server">
                                        <a href="HealthSupervision.aspx">养老人员监督</a>
                                    </li>
                                    <li id="menu2" runat="server">
                                        <a href="HealthDetails.aspx">老人健康监督</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="nav-item nav-item-has-subnav">
                                <a href="javascript:void(0)"><i class="ion-ios-compose-outline"></i>电子病历</a>
                                <ul class="nav nav-subnav">

                                    <li id="old3" runat="server">
                                        <a href="CaseHistory.aspx">个人电子病历</a>
                                    </li>
                                    <li id="menu3" runat="server">
                                        <a href="DcaseHistory.aspx">老人电子病历</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="nav-item nav-item-has-subnav">
                                <a href="javascript:void(0)"><i class="ion-ios-list-outline"></i>社区就诊</a>
                                <ul class="nav nav-subnav">
                                    <li id="old4" runat="server">
                                        <a href="ReservePension.aspx">养老人员预约</a>
                                    </li>
                                    <li id="menu4" runat="server">
                                        <a href="ReserveStaff.aspx">老人预约就诊</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="nav-item active"  id="Li1" runat="server">
                                    <a href="Announcement.aspx"><i class="fa fa-check fa-2x"></i>社区公告栏</a>
                                </li>
                            <li class="nav-item active"  id="menu5" runat="server">
                                    <a href="PersonnelManage.aspx"><i class="fa fa-check fa-2x"></i>系统管理</a>
                                </li>
                        </ul>
                    </nav>
                    <!-- End drawer navigation -->

                    <div class="drawer-footer">
                        <p class="copyright">Copyright &copy; 2019</p>
                    </div>
                </div>
                <!-- End drawer scroll area -->
            </aside>
            <header class="app-layout-header">
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#header-navbar-collapse" aria-expanded="false">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <button class="pull-left hidden-lg hidden-md navbar-toggle" type="button" data-toggle="layout" data-action="sidebar_toggle">
                                <span class="sr-only">Toggle drawer</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <span class="navbar-page-title"></span>
                        </div>
                        <div class="collapse navbar-collapse" id="header-navbar-collapse">
                            <form class="navbar-form navbar-left app-search-form" role="search">
                            </form>
                            <ul class="nav navbar-nav navbar-right navbar-toolbar hidden-sm hidden-xs">
                                <li>
                                    <a href="javascript:void(0)" data-toggle="modal" data-target="#apps-modal"></a>
                                </li>

                                <li class="dropdown">
                                    <a href="javascript:void(0)" data-toggle="dropdown">
                                        <i class="ion-ios-bell"></i>
                                        <span class="badge">3</span>
                                    </a>
                                </li>
                                <li class="dropdown dropdown-profile">
                                    <a href="javascript:void(0)" data-toggle="dropdown">
                                        <span class="m-r-sm">kirito <span class="caret"></span></span>
                                        <img class="img-avatar img-avatar-48" src="assets/img/avatars/avatar3.jpg" alt="User profile pic" />
                                    </a>
                                    <ul class="dropdown-menu dropdown-menu-right">
                                        <li class="dropdown-header">用户设置
                                        </li>
                                        <li>
                                            <a href="Login.aspx">退出登录</a>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </header>

            <main class="app-layout-content" runat="server">
                <form id="Form1" runat="server">
                    <!-- Page Content -->
                    <div class="container-fluid p-y-md">
                        <div id="Div1" class="row" runat="server">
                            <div id="Div2" class="col-md-8" runat="server">
                                <div id="Div4" class="card" runat="server">
                                    <div class="card-block tab-content">
                                        <h4>老人详细信息展示</h4>
                                        <div class="tab-pane fade in active" id="profile-tab1">
                                            <form class="fieldset">
                                                <div class="form-group row">
                                                    <div class="col-xs-6">
                                                        <label for="exampleInputName1" style="font-size:medium">ID：</label>
                                                        <asp:Label ID="lab_ID" runat="server" Text="Label" for="exampleInputName1" style="font-size:medium"></asp:Label>
                                                    </div>
                                                    <div class="col-xs-6">
                                                        <label for="exampleInputName2" style="font-size:medium">姓名：</label>
                                                        <asp:Label ID="lab_UserName" runat="server" Text="Label" for="exampleInputName1" style="font-size:medium"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-xs-6">
                                                        <label for="exampleInputPhone1" style="font-size:medium">记录时间：</label>
                                                        <asp:Label ID="lab_Record" runat="server" Text="Label" for="exampleInputName1" style="font-size:medium"></asp:Label>
                                                    </div>
                                                    <div class="col-xs-6">
                                                        <label for="exampleInputPhone2" style="font-size:medium">体温：</label>
                                                        <asp:Label ID="lab_Tem" runat="server" Text="Label" for="exampleInputName1" style="font-size:medium"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-xs-6">
                                                        <label for="exampleInputPhone1" style="font-size:medium">心率：</label>
                                                        <asp:Label ID="lab_Heart" runat="server" Text="Label" for="exampleInputName1" style="font-size:medium"></asp:Label>
                                                    </div>
                                                    <div class="col-xs-6">
                                                        <label for="exampleInputPhone2" style="font-size:medium">血压：</label>
                                                        <asp:Label ID="lab_Blood" runat="server" Text="Label" for="exampleInputName1" style="font-size:medium"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="btn_Save" runat="server" Text="保存" class="btn btn-sm btn-app" type="button" data-dismiss="modal" OnClick="btnSave_Click"/>
                                                </div>      
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div> 
                    </div>
                        </div>
                    </form>
                </main>
        </div>
    </div>

    <div id="apps-modal" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-sm modal-dialog modal-dialog-top">
            <div class="modal-content">
                <!-- Apps card -->
                <div class="card m-b-0">
                    <div class="card-header bg-app bg-inverse">
                        <h4>Apps</h4>
                        <ul class="card-actions">
                            <li>
                                <button data-dismiss="modal" type="button"><i class="ion-close"></i></button>
                            </li>
                        </ul>
                    </div>
                    <div class="card-block">
                        <div class="row text-center">
                            <div class="col-xs-6">
                                <a class="card card-block m-b-0 bg-app-secondary bg-inverse" href="index.html">
                                    <i class="ion-speedometer fa-4x"></i>
                                    <p>Admin</p>
                                </a>
                            </div>
                            <div class="col-xs-6">
                                <a class="card card-block m-b-0 bg-app-tertiary bg-inverse" href="frontend_home.html">
                                    <i class="ion-laptop fa-4x"></i>
                                    <p>Frontend</p>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="app-ui-mask-modal"></div>

    <script src="assets/js/core/jquery.min.js"></script>
    <script src="assets/js/core/bootstrap.min.js"></script>
    <script src="assets/js/core/jquery.slimscroll.min.js"></script>
    <script src="assets/js/core/jquery.scrollLock.min.js"></script>
    <script src="assets/js/core/jquery.placeholder.min.js"></script>
    <script src="assets/js/app.js"></script>
    <script src="assets/js/app-custom.js"></script>

</body>
</html>
