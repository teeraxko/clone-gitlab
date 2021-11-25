using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
	public class CommonDB : DataAccessBase
	{
//		============================== Constructor ==============================
		public CommonDB() : base()
		{}

//		============================== Public Method ==============================
		public DateTime GetCurrentDate()
		{
			string sql = "SELECT GETDATE() AS Today";
			return (DateTime)tableAccess.ExecuteScalar(sql);
		}


	}
}
