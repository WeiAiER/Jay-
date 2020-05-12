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
    public partial class OldDetail : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"];
        private long id = 0;

        Class_SQL.BLL.Sys_MedicalRacord bll_Medical = new Class_SQL.BLL.Sys_MedicalRacord();
        Class_SQL.DAL.Sys_MedicalRacord dal_Medical = new DAL.Sys_MedicalRacord();
        Class_SQL.Model.Sys_MedicalRacord model_Medical = new Model.Sys_MedicalRacord();

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
                    Alert.AlertAndRedirect("传输参数不正确！", "OldDetail.aspx");
                    return;
                }
                DataSet ds_Register = bll_Medical.GetList("MedicalRecordID = '" + id.ToString() + "'");

                if (ds_Register.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "OldDetail.aspx");
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
            DataSet ds_Medical = bll_Medical.GetList("MedicalRecordID = '" + _id.ToString() + "'");
            lab_ID.Text = ds_Medical.Tables[0].Rows[0]["MedicalRecordID"].ToString();
            lab_UserName.Text = ds_Medical.Tables[0].Rows[0]["UserName"].ToString();
            lab_Clinic.Text = ds_Medical.Tables[0].Rows[0]["DiagnosisTime"].ToString();
            lab_Appointment.Text = ds_Medical.Tables[0].Rows[0]["ReDiagnosisDate"].ToString();
            lab_DoctorName.Text = ds_Medical.Tables[0].Rows[0]["DoctorName"].ToString();
            txt_Examine.Text = ds_Medical.Tables[0].Rows[0]["CheckStatus"].ToString();
            txt_Doctor.Text = ds_Medical.Tables[0].Rows[0]["DoctorSaying"].ToString();
            txt_Illness.Text = ds_Medical.Tables[0].Rows[0]["UserDescription"].ToString();
            txt_Pharmacy.Text = ds_Medical.Tables[0].Rows[0]["Medication"].ToString();
            txt_Result.Text = ds_Medical.Tables[0].Rows[0]["Result"].ToString();
        }
        #endregion
    }
}