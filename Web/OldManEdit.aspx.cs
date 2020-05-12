using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL.Web
{
    public partial class OldManEdit : System.Web.UI.Page
    {
        Class_SQL.BLL.Sys_UserReister bll_UserRegister = new Class_SQL.BLL.Sys_UserReister();
        Class_SQL.Model.Sys_UserReister model_UserRegister = new Model.Sys_UserReister();
        Class_SQL.DAL.Sys_UserReister dal_UserRegister = new DAL.Sys_UserReister();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds_User = bll_UserRegister.GetList("UserID = '" + Session["admin_id"] + "'");

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

            if (!Page.IsPostBack)
            {
                ShowInfo(long.Parse(ds_User.Tables[0].Rows[0]["UserID"].ToString()));
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(long _id)
        {
            //在修改时，给文本框赋值
            DataSet ds_UserRegister = bll_UserRegister.GetList("UserID='" + _id.ToString() + "'");
            txt_OldName.Text = ds_UserRegister.Tables[0].Rows[0]["UserName"].ToString();
            txt_Password.Text = ds_UserRegister.Tables[0].Rows[0]["UserPassword"].ToString();
            txt_PhoneNumber.Text = ds_UserRegister.Tables[0].Rows[0]["PhoneNumber"].ToString();
            txt_Birth.Text = ds_UserRegister.Tables[0].Rows[0]["BirthDate"].ToString();
            txt_Address.Text = ds_UserRegister.Tables[0].Rows[0]["UserAddress"].ToString();
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(string id)
        {
            DataSet ds_UserRegister = bll_UserRegister.GetList("UserID = '" + id + "'");
            if (Session["admin_id"] != null)
            {
                model_UserRegister.UserID = ds_UserRegister.Tables[0].Rows[0]["UserID"].ToString();
                model_UserRegister.UserName = ds_UserRegister.Tables[0].Rows[0]["UserName"].ToString();
                model_UserRegister.UserPassword = txt_Password.Text;
                model_UserRegister.PhoneNumber = txt_PhoneNumber.Text;
                model_UserRegister.UserType = ds_UserRegister.Tables[0].Rows[0]["UserType"].ToString();
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
            DataSet ds_UserRegister = bll_UserRegister.GetList("UserID = '" + Session["admin_id"] + "'");
            
                if (!DoEdit(ds_UserRegister.Tables[0].Rows[0]["UserID"].ToString()))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "OldManEdit.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新信息成功！", "OldMan.aspx");
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("OldMan.aspx");
        }

    }
}