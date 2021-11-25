using System;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.OtherBenefit.Flow
{
	public class ExtraAGTBenefitFlow : FlowBase
	{
		private bool disposed = false;

		public ExtraAGTBenefitFlow() : base()
		{
		}

		public bool GenExtraAGTBenefit()
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