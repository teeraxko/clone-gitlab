using System;
using System.Text;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class VATRateDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public VATRateDB() : base()
		{		
			tableName = "VAT_Rate";
			descColumnName = "VAT_Rate";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new VATRate();
		}

		public VATRate GetVATRate()
		{
			VATRate vatRate = null;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(getSQLSelect());
			try
			{
				if(dataReader.Read())
				{
					vatRate = new VATRate();
					vatRate.Rate = (Decimal)dataReader[0];
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}
			return vatRate;
		}
	}
}