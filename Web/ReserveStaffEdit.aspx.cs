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
    public partial class ReserveStaffEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        Class_SQL.BLL.Sys_Subscribe bll_Sub = new Class_SQL.BLL.Sys_Subscribe();
        Class_SQL.BLL.Sys_UserReister bll_User = new BLL.Sys_UserReister();
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

            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!long.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    Alert.AlertAndRedirect("传输参数不正确！", "ReserveStaffEdit.aspx");
                    return;
                }
                DataSet ds_Sub = bll_Sub.GetList("Subscribe_ID = '" + id.ToString() + "'");

                if (ds_Sub.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "ReserveStaffEdit.aspx");
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
            DataSet ds_Health = bll_Sub.GetList("Subscribe_ID = '" + _id.ToString() + "'");
            txt_OldName.Text = ds_Health.Tables[0].Rows[0]["Subscribe_Name"].ToString();
            txt_Time.Text = ds_Health.Tables[0].Rows[0]["Subscribe_Time"].ToString();
            txt_PName.Text = ds_Health.Tables[0].Rows[0]["Subscribe_FamilyName"].ToString();
            txt_Phone.Text = ds_Health.Tables[0].Rows[0]["Subscribe_FamilyPhone"].ToString();
            txt_Room.Text = ds_Health.Tables[0].Rows[0]["Subscribe_Office"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            DataSet ds_User = bll_User.GetList("UserName = '" + txt_OldName.Text + "'");

            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_Sub.Subscribe_ID= deal.Deal_ID();
                model_Sub.UserID = ds_User.Tables[0].Rows[0]["UserID"].ToString();
                model_Sub.Subscribe_Time = DateTime.Now;
                model_Sub.Subscribe_Name = txt_OldName.Text;
                model_Sub.Subscribe_FamilyName = txt_PName.Text;
                model_Sub.Subscribe_FamilyPhone = txt_Phone.Text;
                model_Sub.Subscribe_Office = txt_Room.Text;
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

        #region 修改操作=================================
        private bool DoEdit(long id)
        {
            DataSet ds_Sub = bll_Sub.GetList("Subscribe_Name = '" + txt_OldName.Text + "'");
            if (Session["admin_id"] != null)
            {
                model_Sub.Subscribe_ID = id.ToString();
                model_Sub.UserID = ds_Sub.Tables[0].Rows[0]["UserID"].ToString();
                model_Sub.Subscribe_Time = DateTime.Now;
                model_Sub.Subscribe_Name = txt_OldName.Text;
                model_Sub.Subscribe_FamilyName = txt_PName.Text;
                model_Sub.Subscribe_FamilyPhone = txt_Phone.Text;
                model_Sub.Subscribe_Office = txt_Room.Text;
                dal_Sub.Update(model_Sub);
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
            if (txt_OldName.Text == "" || txt_Phone.Text == "" || txt_PName.Text == "" || txt_Room.Text == "")
            {
                Alert.AlertAndRedirect("必填信息不能为空！", "ReserveStaffEdit.aspx");
            }
            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "ReserveStaffEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "ReserveStaff.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "ReserveStaffEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "ReserveStaff.aspx");
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("ReserveStaff.aspx");
        }

    }
}