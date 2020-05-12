using Class_SQL.Web;
using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL
{
    public partial class Login : System.Web.UI.Page
    {
        Class_SQL.BLL.Sys_UserReister bll_UserRegister = new Class_SQL.BLL.Sys_UserReister();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Utils ut = new Utils();
                txt_Username.Text = Utils.GetCookie("DTRememberName");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (rb_OldPeople.Checked)
            {
                this.Dispose();
                Response.Redirect("OldmanInformation.aspx");
            }
            if (rb_Doctor.Checked)
            {
                this.Dispose();
                Response.Redirect("DoctorInformation.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet ds_UserRegister = bll_UserRegister.GetList("UserName = '" + txt_Username.Text + "'");
            if (txt_Username.Text == "" || txt_Password.Text == "")
            {
                Alert.AlertAndRedirect("用户名或密码不能为空！", "Login.aspx");
            }
            try
            {
                if (ds_UserRegister.Tables[0].Rows[0]["UserPassword"].ToString() == txt_Password.Text)
                {
                    Session["admin_id"] = ds_UserRegister.Tables[0].Rows[0]["UserID"].ToString();
                    Session["Type"] = ds_UserRegister.Tables[0].Rows[0]["UserType"].ToString();
                    if (Session["type"].Equals("1"))
                    {
                        Alert.AlertAndRedirect("登录成功！", "OldMan.aspx");
                    }
                    if (Session["type"].Equals("2"))
                    {
                        Alert.AlertAndRedirect("登录成功！", "Doctor.aspx");
                    }
                    if (Session["type"].Equals("3"))
                    {
                        Alert.AlertAndRedirect("登录成功！", "Announcement.aspx");
                    }
                }
                else
                {
                    Alert.AlertAndRedirect("登录失败，用户名或密码错误！", "Login.aspx");
                }
            }
            catch (Exception)
            {
                Alert.AlertAndRedirect("登录失败，用户名或密码错误！", "Login.aspx");
            }
        }
    }
}