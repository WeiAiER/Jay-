<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorInformation.aspx.cs" Inherits="Class_SQL.DoctorInformation" %>

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
            <div class="container-fluid p-y-md">
                <div class="row">
                    <div class="col-md-8" style="width: 100%">
                        <div class="card">
                            <div class="card-block tab-content">
                                <h4>注册医生信息填写</h4>
                                <div class="tab-pane fade in active" id="profile-tab1">
                                    <form class="fieldset" runat="server">
                                        <div class="form-group row">
                                            <div class="col-xs-6">
                                                <label for="exampleInputName1">姓名</label>
                                                <%--<input type="text" class="form-control" id="Text7" />--%>
                                                <asp:TextBox ID="txt_DoctorName" runat="server" type="text" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-xs-6">
                                                <label for="exampleInputName2">密码</label>
                                                <%--<input type="text" class="form-control" id="Text8" />--%>
                                                <asp:TextBox ID="txt_DoctorPassword" runat="server" type="text" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-xs-6">
                                                <label for="exampleInputPhone1">联系电话</label>
                                                <%--<input type="tel" class="form-control" id="Tel3" />--%>
                                                <asp:TextBox ID="txt_DoctorPhone" runat="server" type="text" class="form-control"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="form-group row">
                                            <div class="col-xs-6">
                                                <label for="exampleInputPhone2">出生日期</label>
                                                <%--<input type="datetime-local" class="form-control" id="Datetime-local3" />--%>
                                                <asp:TextBox ID="txt_DoctorBirth" runat="server" type="text" class="form-control"></asp:TextBox>
                                                <b><span class="Validform_checktip">*输入格式：2019-05-12</span></b>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-xs-6">
                                                <label for="exampleInputPhone1">家庭住址</label>
                                                <%--<input type="tel" class="form-control" id="Tel6" />--%>
                                                <asp:TextBox ID="txt_DoctorAddress" runat="server" type="text" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row narrow-gutter">
                                            <div class="col-xs-6">
                                                <%--<button type="button" class="btn btn-app btn-block">提交注册信息<span class="hidden-xs"></span></button>--%>
                                                <asp:Button ID="btn_RegisterInformation" runat="server" Text="提交注册信息" type="button" class="btn btn-app btn-block" OnClick="btn_RegisterInformation_Click" />
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="apps-modal" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-sm modal-dialog modal-dialog-top">
            <div class="modal-content">
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
