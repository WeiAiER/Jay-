using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Class_SQL.DAL
{
	/// <summary>
	/// 数据访问类:Sys_MedicalRacord
	/// </summary>
	public partial class Sys_MedicalRacord
	{
		public Sys_MedicalRacord()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MedicalRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_MedicalRacord");
			strSql.Append(" where MedicalRecordID='"+MedicalRecordID+"' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Class_SQL.Model.Sys_MedicalRacord model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.MedicalRecordID != null)
			{
				strSql1.Append("MedicalRecordID,");
				strSql2.Append("'"+model.MedicalRecordID+"',");
			}
			if (model.UserName != null)
			{
				strSql1.Append("UserName,");
				strSql2.Append("'"+model.UserName+"',");
			}
			if (model.DiagnosisTime != null)
			{
				strSql1.Append("DiagnosisTime,");
				strSql2.Append("'"+model.DiagnosisTime+"',");
			}
			if (model.UserDescription != null)
			{
				strSql1.Append("UserDescription,");
				strSql2.Append("'"+model.UserDescription+"',");
			}
			if (model.CheckStatus != null)
			{
				strSql1.Append("CheckStatus,");
				strSql2.Append("'"+model.CheckStatus+"',");
			}
			if (model.Medication != null)
			{
				strSql1.Append("Medication,");
				strSql2.Append("'"+model.Medication+"',");
			}
			if (model.DoctorSaying != null)
			{
				strSql1.Append("DoctorSaying,");
				strSql2.Append("'"+model.DoctorSaying+"',");
			}
			if (model.Result != null)
			{
				strSql1.Append("Result,");
				strSql2.Append("'"+model.Result+"',");
			}
			if (model.ReDiagnosisDate != null)
			{
				strSql1.Append("ReDiagnosisDate,");
				strSql2.Append("'"+model.ReDiagnosisDate+"',");
			}
			if (model.DoctorName != null)
			{
				strSql1.Append("DoctorName,");
				strSql2.Append("'"+model.DoctorName+"',");
			}
			strSql.Append("insert into Sys_MedicalRacord(");
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
		public bool Update(Class_SQL.Model.Sys_MedicalRacord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_MedicalRacord set ");
			if (model.UserName != null)
			{
				strSql.Append("UserName='"+model.UserName+"',");
			}
			if (model.DiagnosisTime != null)
			{
				strSql.Append("DiagnosisTime='"+model.DiagnosisTime+"',");
			}
			if (model.UserDescription != null)
			{
				strSql.Append("UserDescription='"+model.UserDescription+"',");
			}
			if (model.CheckStatus != null)
			{
				strSql.Append("CheckStatus='"+model.CheckStatus+"',");
			}
			if (model.Medication != null)
			{
				strSql.Append("Medication='"+model.Medication+"',");
			}
			if (model.DoctorSaying != null)
			{
				strSql.Append("DoctorSaying='"+model.DoctorSaying+"',");
			}
			if (model.Result != null)
			{
				strSql.Append("Result='"+model.Result+"',");
			}
			if (model.ReDiagnosisDate != null)
			{
				strSql.Append("ReDiagnosisDate='"+model.ReDiagnosisDate+"',");
			}
			if (model.DoctorName != null)
			{
				strSql.Append("DoctorName='"+model.DoctorName+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where MedicalRecordID='"+ model.MedicalRecordID+"' ");
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
		public bool Delete(string MedicalRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_MedicalRacord ");
			strSql.Append(" where MedicalRecordID='"+MedicalRecordID+"' " );
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
		public bool DeleteList(string MedicalRecordIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_MedicalRacord ");
			strSql.Append(" where MedicalRecordID in ("+MedicalRecordIDlist + ")  ");
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
		public Class_SQL.Model.Sys_MedicalRacord GetModel(string MedicalRecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" MedicalRecordID,UserName,DiagnosisTime,UserDescription,CheckStatus,Medication,DoctorSaying,Result,ReDiagnosisDate,DoctorName ");
			strSql.Append(" from Sys_MedicalRacord ");
			strSql.Append(" where MedicalRecordID='"+MedicalRecordID+"' " );
			Class_SQL.Model.Sys_MedicalRacord model=new Class_SQL.Model.Sys_MedicalRacord();
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
		public Class_SQL.Model.Sys_MedicalRacord DataRowToModel(DataRow row)
		{
			Class_SQL.Model.Sys_MedicalRacord model=new Class_SQL.Model.Sys_MedicalRacord();
			if (row != null)
			{
				if(row["MedicalRecordID"]!=null)
				{
					model.MedicalRecordID=row["MedicalRecordID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["DiagnosisTime"]!=null && row["DiagnosisTime"].ToString()!="")
				{
					model.DiagnosisTime=DateTime.Parse(row["DiagnosisTime"].ToString());
				}
				if(row["UserDescription"]!=null)
				{
					model.UserDescription=row["UserDescription"].ToString();
				}
				if(row["CheckStatus"]!=null)
				{
					model.CheckStatus=row["CheckStatus"].ToString();
				}
				if(row["Medication"]!=null)
				{
					model.Medication=row["Medication"].ToString();
				}
				if(row["DoctorSaying"]!=null)
				{
					model.DoctorSaying=row["DoctorSaying"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["ReDiagnosisDate"]!=null && row["ReDiagnosisDate"].ToString()!="")
				{
					model.ReDiagnosisDate=DateTime.Parse(row["ReDiagnosisDate"].ToString());
				}
				if(row["DoctorName"]!=null)
				{
					model.DoctorName=row["DoctorName"].ToString();
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
			strSql.Append("select MedicalRecordID,UserName,DiagnosisTime,UserDescription,CheckStatus,Medication,DoctorSaying,Result,ReDiagnosisDate,DoctorName ");
			strSql.Append(" FROM Sys_MedicalRacord ");
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
			strSql.Append(" MedicalRecordID,UserName,DiagnosisTime,UserDescription,CheckStatus,Medication,DoctorSaying,Result,ReDiagnosisDate,DoctorName ");
			strSql.Append(" FROM Sys_MedicalRacord ");
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
			strSql.Append("select count(1) FROM Sys_MedicalRacord ");
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
				strSql.Append("order by T.MedicalRecordID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_MedicalRacord T ");
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

