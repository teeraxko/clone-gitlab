using System;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.OtherBenefit.Flow
{
	public class ExtraAGTBenefitDeductionFlow : FlowBase
	{
		private bool disposed = false;

		public ExtraAGTBenefitDeductionFlow() : base()
		{
		}

		public bool GenExtraAGTBenefitDeduction()
		{
			return true;
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