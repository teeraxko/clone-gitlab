using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using ictus.Common.Entity;

namespace DataAccess.VehicleDB
{
	public class PaymentTypeDB : DualFieldDBBase
	{
		//		============================== Constructor ==============================
		public PaymentTypeDB() : base()
		{
			tableName = "Payment_Type";
			codeColumnName = "Payment_Type";
			descColumnNameThai = "Payment_Thai_Description";
			descColumnNameEng = "Payment_English_Description";	
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new PaymentType();
		}
	}
}
