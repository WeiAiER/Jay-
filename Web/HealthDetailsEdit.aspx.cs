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
    public partial class HealthDetailsEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

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
            if (!Page.IsPostBack)
            {
                if (action == "Edit") //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_Daily = bll_Daily.GetList("DailyStatusID = '" + _id.ToString() + "'");
            txt_OldName.Text = ds_Daily.Tables[0].Rows[0]["UserName"].ToString();
            txt_Blood.Text = ds_Daily.Tables[0].Rows[0]["BloodPressure"].ToString();
            txt_Health.Text = ds_Daily.Tables[0].Rows[0]["UserHealthState"].ToString();
            txt_Heart.Text = ds_Daily.Tables[0].Rows[0]["UserHeartRate"].ToString();
            txt_Tem.Text = ds_Daily.Tables[0].Rows[0]["UserTemperature"].ToString();
            txt_Time.Text = ds_Daily.Tables[0].Rows[0]["RecordTime"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            DealID deal_User = new DealID();
            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_Daily.DailyStatusID = deal.Deal_ID();
                model_Daily.UserID = deal_User.Deal_ID();
                model_Daily.RecordTime = DateTime.Now;
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

        #region 修改操作=================================
        private bool DoEdit(long id)
        {
            DataSet ds_Daily = bll_Daily.GetList("DailyStatusID = '" + id.ToString() + "'");
            if (Session["admin_id"] != null)
            {
                model_Daily.DailyStatusID = id.ToString();
                model_Daily.UserID = ds_Daily.Tables[0].Rows[0]["UserID"].ToString();
                model_Daily.RecordTime = DateTime.Now;
                model_Daily.BloodPressure = txt_Blood.Text;
                model_Daily.UserName = txt_OldName.Text;
                model_Daily.UserTemperature = txt_Tem.Text;
                model_Daily.UserHeartRate = txt_Heart.Text;
                model_Daily.UserHealthState = txt_Health.Text;
                dal_Daily.Update(model_Daily);
            }
            else
            {
                Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                return false;
            }
            return true;
        }
        #endregion

        ////保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txt_Blood.Text == "" || txt_Health.Text == "" || txt_Heart.Text == "" || txt_OldName.Text == "" || txt_Tem.Text == "")
            {
                Alert.AlertAndRedirect("必填信息不能为空！", "HealthDetails.aspx");
            }
            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "HealthDetailsEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "HealthDetails.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "HealthDetailsEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "HealthDetails.aspx");
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("HealthDetails.aspx");
        }

    }
}