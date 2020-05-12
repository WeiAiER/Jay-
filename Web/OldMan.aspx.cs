using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL
{
    public partial class OldMan : System.Web.UI.Page
    {
        Class_SQL.BLL.Sys_UserReister bll_UserRegister = new BLL.Sys_UserReister();

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

            DataSet ds_UserRegister = bll_UserRegister.GetList("UserID = '" + Session["admin_id"] + "'");
            lab_Name.Text = ds_UserRegister.Tables[0].Rows[0]["UserName"].ToString();
            lab_Password.Text = ds_UserRegister.Tables[0].Rows[0]["UserPassword"].ToString();
            lab_PhoneNumber.Text = ds_UserRegister.Tables[0].Rows[0]["PhoneNumber"].ToString();
            lab_Birth.Text = ds_UserRegister.Tables[0].Rows[0]["BirthDate"].ToString();
            lab_Address.Text = ds_UserRegister.Tables[0].Rows[0]["UserAddress"].ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Response.Redirect("OldManEdit.aspx");
        }

    }
}