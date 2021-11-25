using System;

using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.Report.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class SaleAnnualLeaveFacade : CommonPIFacadeBase
	{
		#region - Private -
		private bool disposed = false;
		private SaleAnnualLeaveFlow flowSaleAnnualLeave;
		private GenerateOtherBenefitFlow flowGenerateOtherBenefit;
		private AnnualLeaveControlFlow flowAnnualLeaveControl;
		private TrAnnualLeaveSaleFlow flowTrAnnualLeaveSale;
		#endregion

		private AnnualLeaveHeadList objAnnualLeaveHeadList;
		public AnnualLeaveHeadList ObjAnnualLeaveHeadList
		{
			get{return objAnnualLeaveHeadList;}
			set{objAnnualLeaveHeadList = value;}
		}

//		==============================  Constructor  ==============================
		public SaleAnnualLeaveFacade() : base()
		{
			flowSaleAnnualLeave = new SaleAnnualLeaveFlow();
			flowGenerateOtherBenefit = new GenerateOtherBenefitFlow();
			flowAnnualLeaveControl = new AnnualLeaveControlFlow();
			flowTrAnnualLeaveSale = new TrAnnualLeaveSaleFlow();
		}

//		============================== Public Method ==============================
		public bool FillAnnualLeaveHeadList(int forYear)
		{
			AnnualLeaveControl annualLeaveControl = flowAnnualLeaveControl.GetAnnualLeaveControl(forYear, GetCompany());
			objAnnualLeaveHeadList = new AnnualLeaveHeadList(annualLeaveControl, GetCompany());
			annualLeaveControl = null;

			return flowSaleAnnualLeave.FillAnnualLeaveHeadList(ref objAnnualLeaveHeadList, forYear);
		}

		public DateTime RetriveDate(DateTime value)
		{
			return flowGenerateOtherBenefit.RetriveDate(value, GetCompany(), 1);
		}

		public bool ProcessSaleAnnualLeave(DateTime value)
		{
			if(objAnnualLeaveHeadList.LeaveControl != null)
			{
				objAnnualLeaveHeadList.LeaveControl.SaleDate = value;
			}
			return flowSaleAnnualLeave.ProcessSaleAnnualLeave(objAnnualLeaveHeadList);
		}

		public bool PrintSaleAnnualLeave(AnnualLeaveSaleList value)
		{
			return flowTrAnnualLeaveSale.PrintAnnualLeaveSale(value);
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
						flowSaleAnnualLeave.Dispose();
						flowGenerateOtherBenefit.Dispose();
						flowAnnualLeaveControl.Dispose();
						objAnnualLeaveHeadList.Dispose();

						flowSaleAnnualLeave = null;
						flowGenerateOtherBenefit = null;
						flowAnnualLeaveControl = null;	
						objAnnualLeaveHeadList = null;
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
