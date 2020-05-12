using System;
namespace Class_SQL.Model
{
	/// <summary>
	/// 0
	/// </summary>
	[Serializable]
	public partial class Sys_Subscribe
	{
		public Sys_Subscribe()
		{}
		#region Model
		private string _subscribe_id;
		private string _subscribe_name;
		private string _userid;
		private DateTime _subscribe_time;
		private string _subscribe_familyname;
		private string _subscribe_familyphone;
		private string _subscribe_office;
		/// <summary>
		/// 
		/// </summary>
		public string Subscribe_ID
		{
			set{ _subscribe_id=value;}
			get{return _subscribe_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subscribe_Name
		{
			set{ _subscribe_name=value;}
			get{return _subscribe_name;}
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
		public DateTime Subscribe_Time
		{
			set{ _subscribe_time=value;}
			get{return _subscribe_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subscribe_FamilyName
		{
			set{ _subscribe_familyname=value;}
			get{return _subscribe_familyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subscribe_FamilyPhone
		{
			set{ _subscribe_familyphone=value;}
			get{return _subscribe_familyphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subscribe_Office
		{
			set{ _subscribe_office=value;}
			get{return _subscribe_office;}
		}
		#endregion Model

	}
}

