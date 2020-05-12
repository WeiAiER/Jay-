using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Class_SQL.DAL
{
	/// <summary>
	/// 数据访问类:Sys_Text
	/// </summary>
	public partial class Sys_Text
	{
		public Sys_Text()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TextNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Text");
			strSql.Append(" where TextNumber='"+TextNumber+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Class_SQL.Model.Sys_Text model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.TextNumber != null)
			{
				strSql1.Append("TextNumber,");
				strSql2.Append("'"+model.TextNumber+"',");
			}
			if (model.TextInfo != null)
			{
				strSql1.Append("TextInfo,");
				strSql2.Append("'"+model.TextInfo+"',");
			}
			if (model.TextTime != null)
			{
				strSql1.Append("TextTime,");
				strSql2.Append("'"+model.TextTime+"',");
			}
			strSql.Append("insert into Sys_Text(");
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
		public bool Update(Class_SQL.Model.Sys_Text model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Text set ");
			if (model.TextInfo != null)
			{
				strSql.Append("TextInfo='"+model.TextInfo+"',");
			}
			if (model.TextTime != null)
			{
				strSql.Append("TextTime='"+model.TextTime+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where TextNumber='"+ model.TextNumber+"' ");
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
		public bool Delete(string TextNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Text ");
			strSql.Append(" where TextNumber='"+TextNumber+"' " );
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
		public bool DeleteList(string TextNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Text ");
			strSql.Append(" where TextNumber in ("+TextNumberlist + ")  ");
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
		public Class_SQL.Model.Sys_Text GetModel(string TextNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" TextNumber,TextInfo,TextTime ");
			strSql.Append(" from Sys_Text ");
			strSql.Append(" where TextNumber='"+TextNumber+"' " );
			Class_SQL.Model.Sys_Text model=new Class_SQL.Model.Sys_Text();
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
		public Class_SQL.Model.Sys_Text DataRowToModel(DataRow row)
		{
			Class_SQL.Model.Sys_Text model=new Class_SQL.Model.Sys_Text();
			if (row != null)
			{
				if(row["TextNumber"]!=null)
				{
					model.TextNumber=row["TextNumber"].ToString();
				}
				if(row["TextInfo"]!=null)
				{
					model.TextInfo=row["TextInfo"].ToString();
				}
				if(row["TextTime"]!=null && row["TextTime"].ToString()!="")
				{
					model.TextTime=DateTime.Parse(row["TextTime"].ToString());
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
			strSql.Append("select TextNumber,TextInfo,TextTime ");
			strSql.Append(" FROM Sys_Text ");
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
			strSql.Append(" TextNumber,TextInfo,TextTime ");
			strSql.Append(" FROM Sys_Text ");
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
			strSql.Append("select count(1) FROM Sys_Text ");
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
				strSql.Append("order by T.TextNumber desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Text T ");
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

