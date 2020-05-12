using System;
namespace Class_SQL.Model
{
	/// <summary>
	/// Sys_MedicalRacord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_MedicalRacord
	{
		public Sys_MedicalRacord()
		{}
		#region Model
		private string _medicalrecordid;
		private string _username;
		private DateTime _diagnosistime;
		private string _userdescription;
		private string _checkstatus;
		private string _medication;
		private string _doctorsaying;
		private string _result;
		private DateTime _rediagnosisdate;
		private string _doctorname;
		/// <summary>
		/// 
		/// </summary>
		public string MedicalRecordID
		{
			set{ _medicalrecordid=value;}
			get{return _medicalrecordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime DiagnosisTime
		{
			set{ _diagnosistime=value;}
			get{return _diagnosistime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserDescription
		{
			set{ _userdescription=value;}
			get{return _userdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckStatus
		{
			set{ _checkstatus=value;}
			get{return _checkstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Medication
		{
			set{ _medication=value;}
			get{return _medication;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DoctorSaying
		{
			set{ _doctorsaying=value;}
			get{return _doctorsaying;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ReDiagnosisDate
		{
			set{ _rediagnosisdate=value;}
			get{return _rediagnosisdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DoctorName
		{
			set{ _doctorname=value;}
			get{return _doctorname;}
		}
		#endregion Model

	}
}

