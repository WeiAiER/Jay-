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
    public partial class DoctorDetail : System.Web.UI.Page
    {
        private string action = HttpContext.Current.Request.QueryString["action"];
        private long id = 0;

        Class_SQL.BLL.Sys_MedicalRacord bll_Medical = new Class_SQL.BLL.Sys_MedicalRacord();
        Class_SQL.DAL.Sys_MedicalRacord dal_Medical = new DAL.Sys_MedicalRacord();
        Class_SQL.Model.Sys_MedicalRacord model_Medical = new Model.Sys_MedicalRacord();
        DealID deal_Medical = new DealID();

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
                    Alert.AlertAndRedirect("传输参数不正确！", "DoctorDetail.aspx");
                    return;
                }
                DataSet ds_Register = bll_Medical.GetList("MedicalRecordID = '" + id.ToString() + "'");

                if (ds_Register.Tables[0].Rows.Count == 0)
                {
                    Alert.AlertAndRedirect("记录不存在或已被删除！", "DoctorDetail.aspx");
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
            txt_OldName.Text = ds_Medical.Tables[0].Rows[0]["UserName"].ToString();
            txt_Visiting.Text = ds_Medical.Tables[0].Rows[0]["DiagnosisTime"].ToString();
            txt_DName.Text = ds_Medical.Tables[0].Rows[0]["DoctorName"].ToString();
            txt_AgainTime.Text = ds_Medical.Tables[0].Rows[0]["ReDiagnosisDate"].ToString();
            txt_Examine.Text = ds_Medical.Tables[0].Rows[0]["CheckStatus"].ToString();
            txt_Doctor.Text = ds_Medical.Tables[0].Rows[0]["DoctorSaying"].ToString();
            txt_Illness.Text = ds_Medical.Tables[0].Rows[0]["UserDescription"].ToString();
            txt_Pharmacy.Text = ds_Medical.Tables[0].Rows[0]["Medication"].ToString();
            txt_Result.Text = ds_Medical.Tables[0].Rows[0]["Result"].ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            if (Session["admin_id"] != null)//如果id不为空，进行赋值
            {
                model_Medical.MedicalRecordID = deal_Medical.Deal_ID();
                model_Medical.UserName = txt_OldName.Text;
                model_Medical.DiagnosisTime = Convert.ToDateTime(txt_Visiting.Text);
                model_Medical.ReDiagnosisDate = Convert.ToDateTime(txt_AgainTime.Text);
                model_Medical.DoctorName = txt_DName.Text;
                model_Medical.CheckStatus = txt_Examine.Text;
                model_Medical.DoctorSaying = txt_Doctor.Text;
                model_Medical.UserDescription = txt_Illness.Text;
                model_Medical.Medication = txt_Pharmacy.Text;
                model_Medical.Result = txt_Result.Text;
                bll_Medical.Add(model_Medical);
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
            if (Session["admin_id"] != null)
            {
                model_Medical.MedicalRecordID = id.ToString();
                model_Medical.UserName = txt_OldName.Text;
                model_Medical.DiagnosisTime = Convert.ToDateTime(txt_Visiting.Text);
                model_Medical.ReDiagnosisDate = Convert.ToDateTime(txt_AgainTime.Text);
                model_Medical.DoctorName = txt_DName.Text;
                model_Medical.CheckStatus = txt_Examine.Text;
                model_Medical.DoctorSaying = txt_Doctor.Text;
                model_Medical.Medication = txt_Pharmacy.Text;
                model_Medical.UserDescription = txt_Illness.Text;
                model_Medical.Result = txt_Result.Text;
                dal_Medical.Update(model_Medical);
            }
            else
            {
                Alert.AlertAndRedirect("会话超时，请重新登录！", "Login.aspx");
                return false;
            }
            return true;
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_DName.Text == "" || txt_Doctor.Text == "" || txt_Examine.Text == "" || txt_Illness.Text == "" || txt_OldName.Text == "" || txt_Pharmacy.Text == "" || txt_Result.Text == "")
            {
                Alert.AlertAndRedirect("必填的信息不能为空！", "DoctorDetail.aspx");
            }
            if (action == "Edit") //修改
            {
                if (!DoEdit(this.id))
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "DoctorDetail.aspx");
                    return;
                }
                Alert.AlertAndRedirect("更新用户成功！", "DoctorDetail.aspx");
            }
            else
            {
                if (!DoAdd())
                {
                    Alert.AlertAndRedirect("保存过程中发生错误！", "DoctorDetail.aspx");
                    return;
                }
                Alert.AlertAndRedirect("添加用户成功！", "DoctorDetail.aspx");
            }
        }
    }
}