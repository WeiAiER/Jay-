using Class_SQL.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Class_SQL
{
    public partial class DoctorInformation : System.Web.UI.Page
    {
        DealID Doc_ID = new DealID();
        Class_SQL.BLL.Sys_UserReister bll_UserRegister = new Class_SQL.BLL.Sys_UserReister();
        Class_SQL.Model.Sys_UserReister model_UserRegister = new Class_SQL.Model.Sys_UserReister();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_RegisterInformation_Click(object sender, EventArgs e)
        {
            DataSet ds_User = bll_UserRegister.GetList("UserName = '" + txt_DoctorName.Text + "'");
            if (ds_User.Tables[0].Rows.Count == 1)
            {
                Alert.AlertAndRedirect("注册用户失败，用户信息已存在", "DoctorInformation.aspx");
                return;
            }

            if (txt_DoctorName.Text == "" || txt_DoctorAddress.Text == "" || txt_DoctorPassword.Text == "" || txt_DoctorPhone.Text == "")
            {
                Alert.AlertAndRedirect("注册用户失败，信息填写不完整", "DoctorInformation.aspx");
                return;
            }

            model_UserRegister.UserID = Doc_ID.Deal_ID();
            model_UserRegister.UserName = txt_DoctorName.Text;
            model_UserRegister.UserPassword = txt_DoctorPassword.Text;
            model_UserRegister.PhoneNumber = txt_DoctorPhone.Text;
            model_UserRegister.UserType = "2";
            model_UserRegister.BirthDate = Convert.ToDateTime(txt_DoctorBirth.Text);
            model_UserRegister.UserAddress = txt_DoctorAddress.Text;
            bll_UserRegister.Add(model_UserRegister);
            Alert.AlertAndRedirect("注册用户成功！", "Login.aspx");
        }
    }
}