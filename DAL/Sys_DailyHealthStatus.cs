using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Class_SQL.DAL
{
	/// <summary>
	/// 数据访问类:Sys_DailyHealthStatus
	/// </summary>
	public partial class Sys_DailyHealthStatus
	{
		public Sys_DailyHealthStatus()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DailyStatusID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_DailyHealthStatus");
			strSql.Append(" where DailyStatusID='"+DailyStatusID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Class_SQL.Model.Sys_DailyHealthStatus model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.DailyStatusID != null)
			{
				strSql1.Append("DailyStatusID,");
				strSql2.Append("'"+model.DailyStatusID+"',");
			}
			if (model.UserID != null)
			{
				strSql1.Append("UserID,");
				strSql2.Append("'"+model.UserID+"',");
			}
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
			strSql.Append("insert into Sys_DailyHealthStatus(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Class_SQL.Model.Sys_DailyHealthStatus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_DailyHealthStatus set ");
			if (model.UserID != null)
			{
				strSql.Append("UserID='"+model.UserID+"',");
			}
			if (model.UserName != null)
			{
				strSql.Append("UserName='"+model.UserName+"',");
			}
			if (model.RecordTime != null)
			{
				strSql.Append("RecordTime='"+model.RecordTime+"',");
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
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where DailyStatusID='"+ model.DailyStatusID+"' ");
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
		public bool Delete(string DailyStatusID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_DailyHealthStatus ");
			strSql.Append(" where DailyStatusID='"+DailyStatusID+"' " );
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
		public bool DeleteList(string DailyStatusIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_DailyHealthStatus ");
			strSql.Append(" where DailyStatusID in ("+DailyStatusIDlist + ")  ");
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
		public Class_SQL.Model.Sys_DailyHealthStatus GetModel(string DailyStatusID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" DailyStatusID,UserID,UserName,RecordTime,UserTemperature,UserHeartRate,BloodPressure,UserHealthState ");
			strSql.Append(" from Sys_DailyHealthStatus ");
			strSql.Append(" where DailyStatusID='"+DailyStatusID+"' " );
			Class_SQL.Model.Sys_DailyHealthStatus model=new Class_SQL.Model.Sys_DailyHealthStatus();
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
		public Class_SQL.Model.Sys_DailyHealthStatus DataRowToModel(DataRow row)
		{
			Class_SQL.Model.Sys_DailyHealthStatus model=new Class_SQL.Model.Sys_DailyHealthStatus();
			if (row != null)
			{
				if(row["DailyStatusID"]!=null)
				{
					model.DailyStatusID=row["DailyStatusID"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["RecordTime"]!=null && row["RecordTime"].ToString()!="")
				{
					model.RecordTime=DateTime.Parse(row["RecordTime"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DailyStatusID,UserID,UserName,RecordTime,UserTemperature,UserHeartRate,BloodPressure,UserHealthState ");
			strSql.Append(" FROM Sys_DailyHealthStatus ");
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
			strSql.Append(" DailyStatusID,UserID,UserName,RecordTime,UserTemperature,UserHeartRate,BloodPressure,UserHealthState ");
			strSql.Append(" FROM Sys_DailyHealthStatus ");
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
			strSql.Append("select count(1) FROM Sys_DailyHealthStatus ");
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
				strSql.Append("order by T.DailyStatusID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_DailyHealthStatus T ");
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

