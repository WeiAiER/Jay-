using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Class_SQL.DAL
{
	/// <summary>
	/// 数据访问类:Sys_Message
	/// </summary>
	public partial class Sys_Message
	{
		public Sys_Message()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Sys_Message"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Message");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Class_SQL.Model.Sys_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.UserName != null)
			{
				strSql1.Append("UserName,");
				strSql2.Append("'"+model.UserName+"',");
			}
			if (model.RecordTime != null)
			{
				strSql1.Append("RecordTime,");
				strSql2.Append("'"+model.RecordTime+"',");
			}
			if (model.DailyStatusID != null)
			{
				strSql1.Append("DailyStatusID,");
				strSql2.Append("'"+model.DailyStatusID+"',");
			}
			if (model.UserTemperature != null)
			{
				strSql1.Append("UserTemperature,");
				strSql2.Append("'"+model.UserTemperature+"',");
			}
			if (model.UserHeartRate != null)
			{
				strSql1.Append("UserHeartRate,");
				strSql2.Append("'"+model.UserHeartRate+"',");
			}
			if (model.BloodPressure != null)
			{
				strSql1.Append("BloodPressure,");
				strSql2.Append("'"+model.BloodPressure+"',");
			}
			if (model.UserHealthState != null)
			{
				strSql1.Append("UserHealthState,");
				strSql2.Append("'"+model.UserHealthState+"',");
			}
			if (model.Message != null)
			{
				strSql1.Append("Message,");
				strSql2.Append("'"+model.Message+"',");
			}
			if (model.Reply != null)
			{
				strSql1.Append("Reply,");
				strSql2.Append("'"+model.Reply+"',");
			}
			if (model.upsize_ts != null)
			{
				strSql1.Append("upsize_ts,");
				strSql2.Append(""+model.upsize_ts+",");
			}
			strSql.Append("insert into Sys_Message(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Class_SQL.Model.Sys_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Message set ");
			if (model.UserName != null)
			{
				strSql.Append("UserName='"+model.UserName+"',");
			}
			if (model.RecordTime != null)
			{
				strSql.Append("RecordTime='"+model.RecordTime+"',");
			}
			if (model.DailyStatusID != null)
			{
				strSql.Append("DailyStatusID='"+model.DailyStatusID+"',");
			}
			if (model.UserTemperature != null)
			{
				strSql.Append("UserTemperature='"+model.UserTemperature+"',");
			}
			if (model.UserHeartRate != null)
			{
				strSql.Append("UserHeartRate='"+model.UserHeartRate+"',");
			}
			if (model.BloodPressure != null)
			{
				strSql.Append("BloodPressure='"+model.BloodPressure+"',");
			}
			if (model.UserHealthState != null)
			{
				strSql.Append("UserHealthState='"+model.UserHealthState+"',");
			}
			if (model.Message != null)
			{
				strSql.Append("Message='"+model.Message+"',");
			}
			else
			{
				strSql.Append("Message= null ,");
			}
			if (model.Reply != null)
			{
				strSql.Append("Reply='"+model.Reply+"',");
			}
			else
			{
				strSql.Append("Reply= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Message ");
			strSql.Append(" where ID="+ID+"" );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Message ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Class_SQL.Model.Sys_Message GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,UserName,RecordTime,DailyStatusID,UserTemperature,UserHeartRate,BloodPressure,UserHealthState,Message,Reply,upsize_ts ");
			strSql.Append(" from Sys_Message ");
			strSql.Append(" where ID="+ID+"" );
			Class_SQL.Model.Sys_Message model=new Class_SQL.Model.Sys_Message();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Class_SQL.Model.Sys_Message DataRowToModel(DataRow row)
		{
			Class_SQL.Model.Sys_Message model=new Class_SQL.Model.Sys_Message();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["RecordTime"]!=null && row["RecordTime"].ToString()!="")
				{
					model.RecordTime=DateTime.Parse(row["RecordTime"].ToString());
				}
				if(row["DailyStatusID"]!=null)
				{
					model.DailyStatusID=row["DailyStatusID"].ToString();
				}
				if(row["UserTemperature"]!=null)
				{
					model.UserTemperature=row["UserTemperature"].ToString();
				}
				if(row["UserHeartRate"]!=null)
				{
					model.UserHeartRate=row["UserHeartRate"].ToString();
				}
				if(row["BloodPressure"]!=null)
				{
					model.BloodPressure=row["BloodPressure"].ToString();
				}
				if(row["UserHealthState"]!=null)
				{
					model.UserHealthState=row["UserHealthState"].ToString();
				}
				if(row["Message"]!=null)
				{
					model.Message=row["Message"].ToString();
				}
				if(row["Reply"]!=null)
				{
					model.Reply=row["Reply"].ToString();
				}
				if(row["upsize_ts"]!=null && row["upsize_ts"].ToString()!="")
				{
					model.upsize_ts=DateTime.Parse(row["upsize_ts"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserName,RecordTime,DailyStatusID,UserTemperature,UserHeartRate,BloodPressure,UserHealthState,Message,Reply,upsize_ts ");
			strSql.Append(" FROM Sys_Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,UserName,RecordTime,DailyStatusID,UserTemperature,UserHeartRate,BloodPressure,UserHealthState,Message,Reply,upsize_ts ");
			strSql.Append(" FROM Sys_Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Sys_Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Message T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

