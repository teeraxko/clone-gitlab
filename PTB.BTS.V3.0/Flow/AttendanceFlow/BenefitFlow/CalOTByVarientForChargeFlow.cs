using System;

using Entity.AttendanceEntities;
using Entity.ContractEntities;

using SystemFramework.AppException;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public class CalOTByVarientForChargeFlow : CalOTByVarientFlow
	{
		#region - Private Method -
		protected override DateTime getEquivalentTime(OTVariant otVariant, Customer customer, DateTime date)
		{
			if(customer != null)
			{
				switch(customer.ACustomerGroup.Code)
				{
					case "G1" :
					{
						return getTime(date ,otVariant.ChargeEquivalentTimeGroupI);
					}
					case "G2" :
					{
						return getTime(date ,otVariant.ChargeEquivalentTimeGroupII);
					}
					case "G3" :
					{
						return getTime(date ,otVariant.ChargeEquivalentTimeGroupIII);
					}
					default :
					{
						throw new NotFoundException("ไม่พบการกำหนดลูกค้า - Family Car", "CalOTByVarientFlow");
					}
				}
			}
			else
			{
				throw new NotFoundException("ไม่พบการกำหนดลูกค้า - Family Car", "CalOTByVarientFlow");
			}
		}
		#endregion

		//============================== Constructor ==============================
		public CalOTByVarientForChargeFlow() : base()
		{
		}
	}
}