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
    public partial class OldmanInformation : System.Web.UI.Page
    {
        DealID Old_ID = new DealID();
        Class_SQL.BLL.Sys_UserReister bll_UserRegister = new Class_SQL.BLL.Sys_UserReister();
        Class_SQL.Model.Sys_UserReister model_UserRegister = new Class_SQL.Model.Sys_UserReister();

        Class_SQL.BLL.Sys_DailyHealthStatus bll_Daily = new BLL.Sys_DailyHealthStatus();
        Class_SQL.Model.Sys_DailyHealthStatus model_Daily = new Model.Sys_DailyHealthStatus();

        Class_SQL.BLL.Sys_MedicalRacord bll_Medical = new BLL.Sys_MedicalRacord();
        Class_SQL.Model.Sys_MedicalRacord model_Medical = new Model.Sys_MedicalRacord();

        Class_SQL.BLL.Sys_Subscribe bll_Sub = new BLL.Sys_Subscribe();
        Class_SQL.Model.Sys_Subscribe model_Sub = new Model.Sys_Subscribe();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Daily()
        {
            DealID Old_ID_One = new DealID();
            DealID Old_ID_Two = new DealID();
            model_Daily.DailyStatusID = Old_ID_One.Deal_ID();
            model_Daily.UserID = Old_ID_Two.Deal_ID();
            model_Daily.UserName = txt_OldName.Text;
            model_Daily.UserTemperature = "暂无体温";
            model_Daily.BloodPressure = "暂无血压";
            model_Daily.UserHeartRate = "暂无心率";
            model_Daily.RecordTime = DateTime.Now;
            model_Daily.UserHealthState = "暂无健康状态";
            bll_Daily.Add(model_Daily);
        }

        protected void Medical()
        {
            DealID Old_ID = new DealID();
            model_Medical.MedicalRecordID = Old_ID.Deal_ID();
            model_Medical.UserName = txt_OldName.Text;
            model_Medical.DiagnosisTime = DateTime.Now;
            model_Medical.UserDescription = "暂无病情";
            model_Medical.CheckStatus = "暂无检查";
            model_Medical.Medication = "暂无用药";
            model_Medical.DoctorSaying = "暂无医嘱";
            model_Medical.DoctorName = "暂无医生查看";
            model_Medical.Result = "暂无结果";
            model_Medical.ReDiagnosisDate = DateTime.Now;
            bll_Medical.Add(model_Medical);
        }

        protected void btn_RegisterInformation_Click(object sender, EventArgs e)
        {
            DataSet ds_User = bll_UserRegister.GetList("UserName = '" + txt_OldName.Text + "'");
            if (ds_User.Tables[0].Rows.Count == 1)
            {
                Alert.AlertAndRedirect("注册用户失败，用户信息已存在", "OldmanInformation.aspx");
                return;
            }

            if (txt_OldName.Text == "" || txt_Address.Text == "" || txt_OldPassword.Text == "" || txt_Phone.Text == "")
            {
                Alert.AlertAndRedirect("注册用户失败，信息填写不完整", "OldmanInformation.aspx");
                return;
            }

            DealID Old_ID_One = new DealID();
            model_UserRegister.UserID = Old_ID_One.Deal_ID();
            model_UserRegister.UserName = txt_OldName.Text;
            model_UserRegister.UserPassword = txt_OldPassword.Text;
            model_UserRegister.PhoneNumber = txt_Phone.Text;
            model_UserRegister.UserType = "1";
            model_UserRegister.BirthDate = Convert.ToDateTime(txt_Birth.Text);
            model_UserRegister.UserAddress = txt_Address.Text;
            bll_UserRegister.Add(model_UserRegister);

            DealID Old_ID_Two = new DealID();
            model_Daily.DailyStatusID = Old_ID_Two.Deal_ID();
            model_Daily.UserID = model_UserRegister.UserID;
            model_Daily.UserName = txt_OldName.Text;
            model_Daily.UserTemperature = "暂无体温";
            model_Daily.BloodPressure = "暂无血压";
            model_Daily.UserHeartRate = "暂无心率";
            model_Daily.RecordTime = DateTime.Now;
            model_Daily.UserHealthState = "暂无健康状态";
            bll_Daily.Add(model_Daily);

            DealID Old_ID_Three = new DealID();
            model_Sub.Subscribe_ID = Old_ID_Three.Deal_ID();
            model_Sub.Subscribe_Name = txt_OldName.Text;
            model_Sub.Subscribe_FamilyName = "暂无家属姓名";
            model_Sub.Subscribe_FamilyPhone = txt_Phone.Text;
            model_Sub.Subscribe_Time = DateTime.Now;
            model_Sub.UserID = model_UserRegister.UserID;
            model_Sub.Subscribe_Office = "暂无预约";
            bll_Sub.Add(model_Sub);

            Medical();
            Alert.AlertAndRedirect("注册用户成功！", "Login.aspx");
        }
    }
}