using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Class_SQL.Model;
namespace Class_SQL.BLL
{
	/// <summary>
	/// Sys_MedicalRacord
	/// </summary>
	public partial class Sys_MedicalRacord
	{
		private readonly Class_SQL.DAL.Sys_MedicalRacord dal=new Class_SQL.DAL.Sys_MedicalRacord();
		public Sys_MedicalRacord()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MedicalRecordID)
		{
			return dal.Exists(MedicalRecordID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Class_SQL.Model.Sys_MedicalRacord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Class_SQL.Model.Sys_MedicalRacord model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string MedicalRecordID)
		{
			
			return dal.Delete(MedicalRecordID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MedicalRecordIDlist )
		{
			return dal.DeleteList(MedicalRecordIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Class_SQL.Model.Sys_MedicalRacord GetModel(string MedicalRecordID)
		{
			
			return dal.GetModel(MedicalRecordID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Class_SQL.Model.Sys_MedicalRacord GetModelByCache(string MedicalRecordID)
		{
			
			string CacheKey = "Sys_MedicalRacordModel-" + MedicalRecordID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MedicalRecordID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Class_SQL.Model.Sys_MedicalRacord)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Class_SQL.Model.Sys_MedicalRacord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Class_SQL.Model.Sys_MedicalRacord> DataTableToList(DataTable dt)
		{
			List<Class_SQL.Model.Sys_MedicalRacord> modelList = new List<Class_SQL.Model.Sys_MedicalRacord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Class_SQL.Model.Sys_MedicalRacord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

