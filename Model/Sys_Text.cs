using System;
namespace Class_SQL.Model
{
	/// <summary>
	/// 0
	/// </summary>
	[Serializable]
	public partial class Sys_Text
	{
		public Sys_Text()
		{}
		#region Model
		private string _textnumber;
		private string _textinfo;
		private DateTime _texttime;
		/// <summary>
		/// 
		/// </summary>
		public string TextNumber
		{
			set{ _textnumber=value;}
			get{return _textnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TextInfo
		{
			set{ _textinfo=value;}
			get{return _textinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TextTime
		{
			set{ _texttime=value;}
			get{return _texttime;}
		}
		#endregion Model

	}
}

