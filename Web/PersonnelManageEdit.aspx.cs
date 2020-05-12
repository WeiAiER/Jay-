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
    public partial class PersonnelManageEdit : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"]; //操作类型
        private long id = 0;

        Class_SQL.BLL.Sys_UserReister bll_UserRegister = new Class_SQL.BLL.Sys_UserReister();
        Class_SQL.DAL.Sys_UserReister dal_UserRegister = new Class_SQL.DAL.Sys_UserReister();
        Class_SQL.Model.Sys_UserReister model_UserRegister = new Class_SQL.Model.Sys_UserReister();
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
                    Alert.AlertAndRedirect("传输参数不正确！", "PersonnelManageEdit.aspx");
                    return;
                }
                DataSet ds_Register = bll_UserRegister.GetList("UserID='" + id.ToString() + "'");

                if (ds_Register.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "PersonnelManageEdit.aspx");
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
            DataSet ds_UserRegister = bll_UserRegister.GetList("UserID='" + _id.ToString() + "'");
            txt_UserName.Text = ds_UserRegister.Tables[0].Rows[0]["UserName"].ToString();
            txt_Password.Text = ds_UserRegister.Tables[0].Rows[0]["UserPassword"].ToString();
            txt_PhoneNumber.Text = ds_UserRegister.Tables[0].Rows[0]["PhoneNumber"].ToString();
            if (ds_UserRegister.Tables[0].Rows[0]["UserType"].ToString() == "1")
            {
                txt_Type.Text = "养老人员";
            }
            if (ds_UserRegister.Tables[0].Rows[0]["UserType"].ToString() == "2")
            {
                txt_Type.Text = "医护人员";
            }
            txt_Birth.Text = ds_UserRegister.Tables[0].Rows[0]["BirthDate"].ToString();
            txt_Address.Text = ds_UserRegister.Tables[0].Rows[0]["UserAddress"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            DataSet ds_UserRegister = bll_UserRegister.GetList("UserName='" + txt_UserName.Text + "'");//从用户表中查列
            if (ds_UserRegister.Tables[0].Rows.Count == 1)//判断是否存在
            {
                Alert.AlertAndRedirect("该用户已存在，请检查！", "PersonnelManageEdit.aspx");
                return false;
            }
            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_UserRegister.UserID = deal.Deal_ID();
                model_UserRegister.UserName = txt_UserName.Text;
                model_UserRegister.UserPassword = txt_Password.Text;
                model_UserRegister.PhoneNumber = txt_PhoneNumber.Text;
                if (txt_Type.Text == "养老人员")
                {
                    model_UserRegister.UserType = "1";
                }
                if (txt_Type.Text == "医护人员")
                {
                    model_UserRegister.UserType = "2";
                }

                model_UserRegister.BirthDate = Convert.ToDateTime(txt_Birth.Text);
                model_UserRegister.UserAddress = txt_Address.Text;
                bll_UserRegister.Add(model_UserRegister);
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
            DataSet ds_User = bll_UserRegister.GetList("UserID = '" + id.ToString() + "'");
            if (Session["admin_id"] != null)
            {
                model_UserRegister.UserID = id.ToString();
                model_UserRegister.UserName = ds_User.Tables[0].Rows[0]["UserName"].ToString();
                model_UserRegister.UserPassword = txt_Password.Text;
                model_UserRegister.PhoneNumber = txt_PhoneNumber.Text;
                model_UserRegister.BirthDate = Convert.ToDateTime(txt_Birth.Text);
                model_UserRegister.UserAddress = txt_Address.Text;
                dal_UserRegister.Update(model_UserRegister);
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
            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "PersonnelManageEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "PersonnelManage.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "PersonnelManageEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "PersonnelManage.aspx");
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("PersonnelManage.aspx");
        }
    }
}