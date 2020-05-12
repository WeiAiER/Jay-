using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL.Web
{
    public partial class AddReserve : System.Web.UI.Page
    {
        Class_SQL.BLL.Sys_Subscribe bll_Sub = new Class_SQL.BLL.Sys_Subscribe();
        Class_SQL.DAL.Sys_Subscribe dal_Sub = new Class_SQL.DAL.Sys_Subscribe();
        Class_SQL.Model.Sys_Subscribe model_Sub = new Class_SQL.Model.Sys_Subscribe();
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

            lblBenDiShiJian.Text = System.DateTime.Now.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblState.Text = calDate.SelectedDate.ToShortDateString();
        }

        #region 增加操作=================================
        private bool DoAdd()
        {
            DataSet ds_Sub = bll_Sub.GetList("UserID = '" + Session["admin_id"] + "'");//从部门表中查列

            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_Sub.Subscribe_ID = deal.Deal_ID();
                model_Sub.Subscribe_Name = ds_Sub.Tables[0].Rows[0]["Subscribe_Name"].ToString();
                model_Sub.UserID = ds_Sub.Tables[0].Rows[0]["UserID"].ToString();
                model_Sub.Subscribe_Time = Convert.ToDateTime(lblState.Text);
                model_Sub.Subscribe_FamilyName = ds_Sub.Tables[0].Rows[0]["Subscribe_FamilyName"].ToString();
                model_Sub.Subscribe_FamilyPhone = ds_Sub.Tables[0].Rows[0]["Subscribe_FamilyPhone"].ToString();
                model_Sub.Subscribe_Office = "暂无";
                bll_Sub.Add(model_Sub);
            }
            else
            {
                Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                return false;
            }
            return true;
        }
        #endregion

        protected void btn_Order_Click(object sender, EventArgs e)
        {
            if (!DoAdd())
            {
                Alert.AlertAndRedirect("保存过程中发生错误！", "AddReserve.aspx");
                return;
            }
            Alert.AlertAndRedirect("预约成功！", "ReservePension.aspx");
        }
    }
}