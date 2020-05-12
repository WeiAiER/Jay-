<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="Class_SQL.Web.Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td valign="top">
                <div>
                    <h2 class="info2">
                    </h2>
                    <h2 class="info2">
                        &nbsp;</h2>
                    <h2 class="info2">
                        留言板</h2>
						
                    <ul class="list">
                        <table id="TABLE1" runat="server" cellpadding="2" cellspacing="15" width="100%">
                            <tr>
                                <td colspan="2" style="height: 28px">
                                    <asp:Repeater ID="rptMR" runat="server">
                                        <HeaderTemplate>

                                        </HeaderTemplate>
                                        <ItemTemplate> <table id="mess" style="width: 85%; text-align: left; margin-top: 2px; margin-bottom: 10px;">
                                            <tr>
                                                <td>
                                                    老人姓名：<%#Eval("UserName") %><br />
                                                    测量时间：<%#Eval("RecordTime") %><br />
                                                    心率：<%#Eval("UserHeartRate") %><br />
                                                    血压：<%#Eval("BloodPressure") %><br />
                                                    体温：<%#Eval("UserTemperature") %><br />
                                                    健康状态：<%#Eval("UserHealthState") %><br />
                                                    留言内容：</td>
                                            </tr>
                                            <tr>
                                                <td style="text-indent: 2em;">
                                                    <%#Eval("Message") %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    回复内容：</td>
                                            </tr>
                                            <tr>
                                                <td style="text-indent: 2em;">
                                                    <%#Eval("Reply") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table></FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 28px">
                                    <table class="style1" style="margin-top: 20px">
                                        <tr>
                                            <td colspan="2">
                                                评论内容：</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:TextBox ID="TextBox1" runat="server" Height="152px" TextMode="MultiLine" Width="626px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btSubmit" runat="server" OnClick="btSubmit_Click" Text="提交评论" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 28px">
                                    <table class="style1" style="margin-top: 20px">
                                        <tr>
                                            <td colspan="2">
                                                回复内容：</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:TextBox ID="TextBox2" runat="server" Height="152px" TextMode="MultiLine" Width="626px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btReply" runat="server" OnClick="btReply_Click" Text="提交回复" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btBack" runat="server" OnClick="btBack_Click" Text="返回上一页" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ul>
                </div>
                <div align="center" class="clear">
                    &nbsp;</div>
            </td>
        </tr>
    </table>
</asp:Content>
