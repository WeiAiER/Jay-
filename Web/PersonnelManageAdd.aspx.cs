using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL.Web
{
    public partial class PersonnelManageAdd : System.Web.UI.Page
    {
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
        }

        #region 增加操作=================================
        private bool DoAdd()
        {
            DataSet ds_UserRegister = bll_UserRegister.GetList("UserName='" + txt_UserName.Text + "'");//从用户表中查列
            if (ds_UserRegister.Tables[0].Rows.Count == 1)//判断是否存在
            {
                Alert.AlertAndRedirect("该用户已存在，请检查！", "PersonnelManageAdd.aspx");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!DoAdd())
            {
                Alert.AlertAndRedirect("保存过程中发生错误！", "PersonnelManageAdd.aspx");
                return;
            }
            Alert.AlertAndRedirect("添加用户成功！", "PersonnelManage.aspx");
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("PersonnelManage.aspx");
        }

    }
}