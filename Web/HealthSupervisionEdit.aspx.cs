using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL.Web
{
    public partial class HealthSupervisionEdit : System.Web.UI.Page
    {
        Class_SQL.BLL.Sys_DailyHealthStatus bll_Daily = new BLL.Sys_DailyHealthStatus();
        Class_SQL.DAL.Sys_DailyHealthStatus dal_Daily = new Class_SQL.DAL.Sys_DailyHealthStatus();
        Class_SQL.Model.Sys_DailyHealthStatus model_Daily = new Class_SQL.Model.Sys_DailyHealthStatus();
        DealID deal = new DealID();

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
        }

        #region 增加操作=================================
        private bool DoAdd()
        {
            DealID deal_User = new DealID();
            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_Daily.DailyStatusID = deal.Deal_ID();
                model_Daily.UserID = deal_User.Deal_ID();
                model_Daily.RecordTime = Convert.ToDateTime(txt_Time.Text);
                model_Daily.BloodPressure = txt_Blood.Text;
                model_Daily.UserName = txt_OldName.Text;
                model_Daily.UserTemperature = txt_Tem.Text;
                model_Daily.UserHeartRate = txt_Heart.Text;
                model_Daily.UserHealthState = txt_Health.Text;
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txt_Blood.Text == "" || txt_Health.Text == "" || txt_Heart.Text == "" || txt_OldName.Text == "" || txt_Tem.Text == "")
            {
                Alert.AlertAndRedirect("必填信息不能为空！", "HealthSupervisionEdit.aspx");
            }
            if (!DoAdd())
            {
                Alert.AlertAndRedirect("保存过程中发生错误！", "HealthSupervisionEdit.aspx");
                return;
            }
            Alert.AlertAndRedirect("添加用户成功！", "HealthSupervision.aspx");
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("HealthSupervision.aspx");
        }

    }
}