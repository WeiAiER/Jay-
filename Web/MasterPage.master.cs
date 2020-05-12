using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Class_SQL.Web;
public partial class MasterPage : System.Web.UI.MasterPage
{

    public string MusicPath;
    SqlHelper data = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin/Default.aspx");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["User"] = null;
        Session["UserName"] = null;
        Alert.AlertAndRedirect("退出成功", "Default.aspx");
    }
}
