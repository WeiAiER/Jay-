using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Class_SQL.DAL
{
	/// <summary>
	/// 数据访问类:Sys_UserReister
	/// </summary>
	public partial class Sys_UserReister
	{
		public Sys_UserReister()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_UserReister");
			strSql.Append(" where UserID='"+UserID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Class_SQL.Model.Sys_UserReister model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
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
			if (model.UserPassword != null)
			{
				strSql1.Append("UserPassword,");
				strSql2.Append("'"+model.UserPassword+"',");
			}
			if (model.PhoneNumber != null)
			{
				strSql1.Append("PhoneNumber,");
				strSql2.Append("'"+model.PhoneNumber+"',");
			}
			if (model.UserType != null)
			{
				strSql1.Append("UserType,");
				strSql2.Append("'"+model.UserType+"',");
			}
			if (model.BirthDate != null)
			{
				strSql1.Append("BirthDate,");
				strSql2.Append("'"+model.BirthDate+"',");
			}
			if (model.UserAddress != null)
			{
				strSql1.Append("UserAddress,");
				strSql2.Append("'"+model.UserAddress+"',");
			}
			strSql.Append("insert into Sys_UserReister(");
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
		public bool Update(Class_SQL.Model.Sys_UserReister model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_UserReister set ");
			if (model.UserName != null)
			{
				strSql.Append("UserName='"+model.UserName+"',");
			}
			if (model.UserPassword != null)
			{
				strSql.Append("UserPassword='"+model.UserPassword+"',");
			}
			if (model.PhoneNumber != null)
			{
				strSql.Append("PhoneNumber='"+model.PhoneNumber+"',");
			}
			if (model.UserType != null)
			{
				strSql.Append("UserType='"+model.UserType+"',");
			}
			if (model.BirthDate != null)
			{
				strSql.Append("BirthDate='"+model.BirthDate+"',");
			}
			if (model.UserAddress != null)
			{
				strSql.Append("UserAddress='"+model.UserAddress+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where UserID='"+ model.UserID+"' ");
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
		public bool Delete(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UserReister ");
			strSql.Append(" where UserID='"+UserID+"' " );
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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_UserReister ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public Class_SQL.Model.Sys_UserReister GetModel(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" UserID,UserName,UserPassword,PhoneNumber,UserType,BirthDate,UserAddress ");
			strSql.Append(" from Sys_UserReister ");
			strSql.Append(" where UserID='"+UserID+"' " );
			Class_SQL.Model.Sys_UserReister model=new Class_SQL.Model.Sys_UserReister();
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
		public Class_SQL.Model.Sys_UserReister DataRowToModel(DataRow row)
		{
			Class_SQL.Model.Sys_UserReister model=new Class_SQL.Model.Sys_UserReister();
			if (row != null)
			{
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserPassword"]!=null)
				{
					model.UserPassword=row["UserPassword"].ToString();
				}
				if(row["PhoneNumber"]!=null)
				{
					model.PhoneNumber=row["PhoneNumber"].ToString();
				}
				if(row["UserType"]!=null)
				{
					model.UserType=row["UserType"].ToString();
				}
				if(row["BirthDate"]!=null && row["BirthDate"].ToString()!="")
				{
					model.BirthDate=DateTime.Parse(row["BirthDate"].ToString());
				}
				if(row["UserAddress"]!=null)
				{
					model.UserAddress=row["UserAddress"].ToString();
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
			strSql.Append("select UserID,UserName,UserPassword,PhoneNumber,UserType,BirthDate,UserAddress ");
			strSql.Append(" FROM Sys_UserReister ");
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
			strSql.Append(" UserID,UserName,UserPassword,PhoneNumber,UserType,BirthDate,UserAddress ");
			strSql.Append(" FROM Sys_UserReister ");
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
			strSql.Append("select count(1) FROM Sys_UserReister ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_UserReister T ");
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

