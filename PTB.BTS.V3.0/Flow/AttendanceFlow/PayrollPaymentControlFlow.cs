using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	public class PayrollPaymentControlFlow : FlowBase
	{
		#region - Private -
		private PayrollPaymentControlDB dbPayrollPaymentControl;
		#endregion - Private -

//		============================== Constructor ==============================
		public PayrollPaymentControlFlow() : base()
		{
			dbPayrollPaymentControl = new PayrollPaymentControlDB();
		}

//		============================== Public Method ==============================
		public bool FillPayrollPaymentControlList(ref PayrollPaymentControlList value)
		{
			return dbPayrollPaymentControl.FillPayrollPaymentControlList(ref value);
		}

		public bool FillPayrollPaymentControl(ref PayrollPaymentControl value, Company aCompany)
		{
			return dbPayrollPaymentControl.FillPayrollPaymentControl(ref value, aCompany);
		}

		public bool InsertPayrollPaymentControl(PayrollPaymentControl value, Company aCompany)
		{
			return dbPayrollPaymentControl.InsertPayrollPaymentControl(value, aCompany);
		}

		public bool UpdatePayrollPaymentControl(PayrollPaymentControl value, Company aCompany)
		{
			return dbPayrollPaymentControl.UpdatePayrollPaymentControl(value, aCompany);	
		}
		
		public bool DeletePayrollPaymentControl(PayrollPaymentControl value, Company aCompany)
		{
			return dbPayrollPaymentControl.DeletePayrollPaymentControl(value, aCompany);		
		}
	}
}
