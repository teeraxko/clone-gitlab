using System;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.OtherBenefit.Flow
{
	public class TelephoneBenefitFlow : FlowBase
	{
		private bool disposed = false;

//		============================== Constructor ==============================
		public TelephoneBenefitFlow() : base()
		{
		}

//		============================== Public Method ==============================
		public bool GenTelephoneBenefit(YearMonth yearMonth, Company aCompany)
		{
			bool result = true;

			TelephoneConditionList objTelephoneConditionList = new TelephoneConditionList(aCompany);
			TelephoneConditionDB dbTelephoneCondition = new TelephoneConditionDB();
			EmployeeTelephoneBenefitDB dbEmployeeTelephoneBenefit = new EmployeeTelephoneBenefitDB();	
			TelephoneBenefit objTelephoneBenefit;

			if(dbTelephoneCondition.FillTelephoneConditionList(ref objTelephoneConditionList))
			{
				//Gen_Telephone
				for(int i=0; i<objTelephoneConditionList.Count; i++)
				{
					objTelephoneBenefit = new TelephoneBenefit();
					objTelephoneBenefit.AYearMonth = yearMonth;
					objTelephoneBenefit.TotalAmount = objTelephoneConditionList[i].TelephoneRate;
					objTelephoneBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;

					dbEmployeeTelephoneBenefit.DeleteTelephoneBenefit(objTelephoneBenefit, objTelephoneConditionList[i].AEmployee);
					result &= dbEmployeeTelephoneBenefit.InsertTelephoneBenefit(objTelephoneBenefit, objTelephoneConditionList[i].AEmployee);
				}
			}
			return result;
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}