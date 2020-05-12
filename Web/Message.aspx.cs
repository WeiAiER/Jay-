using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL.Web
{
    public partial class Message : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        SqlHelper data = new SqlHelper();
        Class_SQL.BLL.Sys_DailyHealthStatus bll_Daily = new BLL.Sys_DailyHealthStatus();
        Class_SQL.BLL.Sys_Message bll_Message = new BLL.Sys_Message();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "HealthDetailsEdit.aspx");
                    return;
                }
                DataSet ds_Register = bll_Daily.GetList("DailyStatusID = '" + id.ToString() + "'");

                if (ds_Register.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "HealthDetailsEdit.aspx");
                    return;
                }
            }

            if (!IsPostBack)
            {
                rptMR.DataSource = data.GetDataReader("select * from Sys_Message");
                rptMR.DataBind();
            }
        }


        protected void btSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds_Daily = bll_Daily.GetList("DailyStatusID = '" + id.ToString() + "'");

            if (Session["Type"].Equals("1"))
            {
                Alert.AlertAndRedirect("您无法参加评论！", "Message.aspx");
                return;
            }

            string sql = "insert  into [Sys_Message](DailyStatusID,Message,UserName,RecordTime,UserHeartRate,BloodPressure,UserTemperature,UserHealthState)values('" + ds_Daily.Tables[0].Rows[0]["DailyStatusID"].ToString() + "','" + TextBox1.Text + "','" + ds_Daily.Tables[0].Rows[0]["UserName"].ToString() + "','" + ds_Daily.Tables[0].Rows[0]["RecordTime"].ToString() + "','" + ds_Daily.Tables[0].Rows[0]["UserHeartRate"].ToString() + "','" + ds_Daily.Tables[0].Rows[0]["BloodPressure"].ToString() + "','" + ds_Daily.Tables[0].Rows[0]["UserTemperature"].ToString() + "','" + ds_Daily.Tables[0].Rows[0]["UserHealthState"].ToString() + "')";
            data.RunSql(sql);
            Alert.AlertAndRedirect("感谢您的留言", "Message.aspx");
        }

        protected void btReply_Click(object sender, EventArgs e)
        {
            DataSet ds_Daily = bll_Daily.GetList("DailyStatusID = '" + id.ToString() + "'");
            DataSet ds_Message = bll_Message.GetList("");

            if (Session["Type"].Equals("2"))
            {
                Alert.AlertAndRedirect("您无法参加回复！", "Message.aspx");
                return;
            }

            try
            {
                int x = 0;
                foreach (DataRow row in ds_Message.Tables[0].Rows)
                {
                    if (ds_Message.Tables[0].Rows[x]["UserName"].ToString() != ds_Daily.Tables[0].Rows[x]["UserName"].ToString())
                    {
                        Alert.AlertAndRedirect("暂没有对您的身体情况的评价！", "Message.aspx");
                        return;
                    }
                    if (ds_Message.Tables[0].Rows[x]["UserName"].ToString() == ds_Daily.Tables[0].Rows[x]["UserName"].ToString())
                    {
                        break;
                    }
                    x++;
                }
            }
            catch (Exception)
            {

            }

            string sql = "update [Sys_Message] set Reply = '" + TextBox2.Text + "' where UserName  = '" + ds_Daily.Tables[0].Rows[0]["UserName"].ToString() + "'";
            try
            {
                data.RunSql(sql);
            }
            catch (Exception)
            {
                throw;
            }
            Alert.AlertAndRedirect("感谢您的回复", "Message.aspx");
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("HealthDetails.aspx");
        }
    }
}