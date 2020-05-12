using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Class_SQL.DAL
{
	/// <summary>
	/// 数据访问类:Sys_Subscribe
	/// </summary>
	public partial class Sys_Subscribe
	{
		public Sys_Subscribe()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Subscribe_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Subscribe");
			strSql.Append(" where Subscribe_ID='"+Subscribe_ID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Class_SQL.Model.Sys_Subscribe model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Subscribe_ID != null)
			{
				strSql1.Append("Subscribe_ID,");
				strSql2.Append("'"+model.Subscribe_ID+"',");
			}
			if (model.Subscribe_Name != null)
			{
				strSql1.Append("Subscribe_Name,");
				strSql2.Append("'"+model.Subscribe_Name+"',");
			}
			if (model.UserID != null)
			{
				strSql1.Append("UserID,");
				strSql2.Append("'"+model.UserID+"',");
			}
			if (model.Subscribe_Time != null)
			{
				strSql1.Append("Subscribe_Time,");
				strSql2.Append("'"+model.Subscribe_Time+"',");
			}
			if (model.Subscribe_FamilyName != null)
			{
				strSql1.Append("Subscribe_FamilyName,");
				strSql2.Append("'"+model.Subscribe_FamilyName+"',");
			}
			if (model.Subscribe_FamilyPhone != null)
			{
				strSql1.Append("Subscribe_FamilyPhone,");
				strSql2.Append("'"+model.Subscribe_FamilyPhone+"',");
			}
			if (model.Subscribe_Office != null)
			{
				strSql1.Append("Subscribe_Office,");
				strSql2.Append("'"+model.Subscribe_Office+"',");
			}
			strSql.Append("insert into Sys_Subscribe(");
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
		public bool Update(Class_SQL.Model.Sys_Subscribe model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Subscribe set ");
			if (model.Subscribe_Name != null)
			{
				strSql.Append("Subscribe_Name='"+model.Subscribe_Name+"',");
			}
			if (model.UserID != null)
			{
				strSql.Append("UserID='"+model.UserID+"',");
			}
			if (model.Subscribe_Time != null)
			{
				strSql.Append("Subscribe_Time='"+model.Subscribe_Time+"',");
			}
			if (model.Subscribe_FamilyName != null)
			{
				strSql.Append("Subscribe_FamilyName='"+model.Subscribe_FamilyName+"',");
			}
			if (model.Subscribe_FamilyPhone != null)
			{
				strSql.Append("Subscribe_FamilyPhone='"+model.Subscribe_FamilyPhone+"',");
			}
			if (model.Subscribe_Office != null)
			{
				strSql.Append("Subscribe_Office='"+model.Subscribe_Office+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where Subscribe_ID='"+ model.Subscribe_ID+"' ");
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
		public bool Delete(string Subscribe_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Subscribe ");
			strSql.Append(" where Subscribe_ID='"+Subscribe_ID+"' " );
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
		public bool DeleteList(string Subscribe_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Subscribe ");
			strSql.Append(" where Subscribe_ID in ("+Subscribe_IDlist + ")  ");
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
		public Class_SQL.Model.Sys_Subscribe GetModel(string Subscribe_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" Subscribe_ID,Subscribe_Name,UserID,Subscribe_Time,Subscribe_FamilyName,Subscribe_FamilyPhone,Subscribe_Office ");
			strSql.Append(" from Sys_Subscribe ");
			strSql.Append(" where Subscribe_ID='"+Subscribe_ID+"' " );
			Class_SQL.Model.Sys_Subscribe model=new Class_SQL.Model.Sys_Subscribe();
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
		public Class_SQL.Model.Sys_Subscribe DataRowToModel(DataRow row)
		{
			Class_SQL.Model.Sys_Subscribe model=new Class_SQL.Model.Sys_Subscribe();
			if (row != null)
			{
				if(row["Subscribe_ID"]!=null)
				{
					model.Subscribe_ID=row["Subscribe_ID"].ToString();
				}
				if(row["Subscribe_Name"]!=null)
				{
					model.Subscribe_Name=row["Subscribe_Name"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["Subscribe_Time"]!=null && row["Subscribe_Time"].ToString()!="")
				{
					model.Subscribe_Time=DateTime.Parse(row["Subscribe_Time"].ToString());
				}
				if(row["Subscribe_FamilyName"]!=null)
				{
					model.Subscribe_FamilyName=row["Subscribe_FamilyName"].ToString();
				}
				if(row["Subscribe_FamilyPhone"]!=null)
				{
					model.Subscribe_FamilyPhone=row["Subscribe_FamilyPhone"].ToString();
				}
				if(row["Subscribe_Office"]!=null)
				{
					model.Subscribe_Office=row["Subscribe_Office"].ToString();
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
			strSql.Append("select Subscribe_ID,Subscribe_Name,UserID,Subscribe_Time,Subscribe_FamilyName,Subscribe_FamilyPhone,Subscribe_Office ");
			strSql.Append(" FROM Sys_Subscribe ");
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
			strSql.Append(" Subscribe_ID,Subscribe_Name,UserID,Subscribe_Time,Subscribe_FamilyName,Subscribe_FamilyPhone,Subscribe_Office ");
			strSql.Append(" FROM Sys_Subscribe ");
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
			strSql.Append("select count(1) FROM Sys_Subscribe ");
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
				strSql.Append("order by T.Subscribe_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Subscribe T ");
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

