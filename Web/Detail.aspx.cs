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
    public partial class Detail : System.Web.UI.Page
    {
        Class_SQL.BLL.Sys_DailyHealthStatus bll_Daily = new BLL.Sys_DailyHealthStatus();
        Class_SQL.DAL.Sys_DailyHealthStatus dal_Daily = new DAL.Sys_DailyHealthStatus();
        Class_SQL.Model.Sys_DailyHealthStatus model_Daily = new Model.Sys_DailyHealthStatus();
        DealID deal_Health = new DealID();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"].Equals("1"))
            {
                menu1.Visible = false;
                menu2.Visible = false;
                menu3.Visible = false;
                menu4.Visible = false;
                menu5.Visible = false;
            }
            if (Session["Type"].Equals("2"))
            {
                old1.Visible = false;
                old2.Visible = false;
                old3.Visible = false;
                old4.Visible = false;
                menu5.Visible = false;
            }
            if (Session["Type"].Equals("3"))
            {
                menu1.Visible = false;
                menu2.Visible = false;
                menu3.Visible = false;
                menu4.Visible = false;
                old1.Visible = false;
                old2.Visible = false;
                old3.Visible = false;
                old4.Visible = false;
            }

            DataSet ds_Daily = bll_Daily.GetList("UserID = '" + Session["admin_id"] + "'");
            lab_ID.Text = ds_Daily.Tables[0].Rows[0]["DailyStatusID"].ToString();
            lab_UserName.Text = ds_Daily.Tables[0].Rows[0]["UserName"].ToString();
            lab_Record.Text = ds_Daily.Tables[0].Rows[0]["RecordTime"].ToString();
            lab_Tem.Text = ds_Daily.Tables[0].Rows[0]["UserTemperature"].ToString();
            lab_Blood.Text = ds_Daily.Tables[0].Rows[0]["BloodPressure"].ToString();
            lab_Heart.Text = ds_Daily.Tables[0].Rows[0]["UserHeartRate"].ToString();
        }


        #region 增加操作=================================
        private bool DoAdd()
        {
            DealID deal_User = new DealID();
            DataSet ds_Daily = bll_Daily.GetList("UserName = '" + lab_UserName.Text + "'");
            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_Daily.DailyStatusID = deal_Health.Deal_ID();
                model_Daily.UserID = deal_User.Deal_ID();
                model_Daily.RecordTime = DateTime.Now;
                model_Daily.BloodPressure = lab_Blood.Text;
                model_Daily.UserName = lab_UserName.Text;
                model_Daily.UserTemperature = lab_Tem.Text;
                model_Daily.UserHeartRate = lab_Heart.Text;
                model_Daily.UserHealthState = ds_Daily.Tables[0].Rows[0]["UserHealthState"].ToString();
                bll_Daily.Add(model_Daily);
            }
            else
            {
                Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                return false;
            }
            return true;
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!DoAdd())
            {
                Alert.AlertAndRedirect("保存过程中发生错误！", "Detail.aspx");
                return;
            }
            Alert.AlertAndRedirect("保存成功！", "HealthSupervision.aspx");
        }
    }
}