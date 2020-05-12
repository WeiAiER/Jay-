using System;
namespace Class_SQL.Model
{
	/// <summary>
	/// Sys_DailyHealthStatus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_DailyHealthStatus
	{
		public Sys_DailyHealthStatus()
		{}
		#region Model
		private string _dailystatusid;
		private string _userid;
		private string _username;
		private DateTime _recordtime;
		private string _usertemperature;
		private string _userheartrate;
		private string _bloodpressure;
		private string _userhealthstate;
		/// <summary>
		/// 
		/// </summary>
		public string DailyStatusID
		{
			set{ _dailystatusid=value;}
			get{return _dailystatusid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
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
		public DateTime RecordTime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserTemperature
		{
			set{ _usertemperature=value;}
			get{return _usertemperature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserHeartRate
		{
			set{ _userheartrate=value;}
			get{return _userheartrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BloodPressure
		{
			set{ _bloodpressure=value;}
			get{return _bloodpressure;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserHealthState
		{
			set{ _userhealthstate=value;}
			get{return _userhealthstate;}
		}
		#endregion Model

	}
}

