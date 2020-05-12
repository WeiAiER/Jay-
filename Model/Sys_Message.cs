using System;
namespace Class_SQL.Model
{
	/// <summary>
	/// 0
	/// </summary>
	[Serializable]
	public partial class Sys_Message
	{
		public Sys_Message()
		{}
		#region Model
		private int _id;
		private string _username;
		private DateTime _recordtime;
		private string _dailystatusid;
		private string _usertemperature;
		private string _userheartrate;
		private string _bloodpressure;
		private string _userhealthstate;
		private string _message="";
		private string _reply="";
		private DateTime? _upsize_ts;
		/// <summary>
		/// -1
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public string DailyStatusID
		{
			set{ _dailystatusid=value;}
			get{return _dailystatusid;}
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
		/// <summary>
		/// -1
		/// </summary>
		public string Message
		{
			set{ _message=value;}
			get{return _message;}
		}
		/// <summary>
		/// -1
		/// </summary>
		public string Reply
		{
			set{ _reply=value;}
			get{return _reply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? upsize_ts
		{
			set{ _upsize_ts=value;}
			get{return _upsize_ts;}
		}
		#endregion Model

	}
}

