using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

using Entity.ContractEntities;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities 
{	
	public class HolidayCondition : EntityBase, IKey
	{
//		============================== Property ==============================
		private PositionType aPositionType;
		public PositionType APositionType
		{
			set{aPositionType = value;}
			get{return aPositionType;}
		}
	
		private ServiceStaffType aServiceStaffType;
		public ServiceStaffType AServiceStaffType
		{
			get{return aServiceStaffType;}
			set{aServiceStaffType = value;}
		}

		private CustomerDepartment aCustomerDepartment;
		public CustomerDepartment ACustomerDepartment
		{
			get{return aCustomerDepartment;}
			set{aCustomerDepartment = value;}
		}

		private HIRE_DATE_STATUS_TYPE hireDateStatus = HIRE_DATE_STATUS_TYPE.NULL;
		public HIRE_DATE_STATUS_TYPE HireDateStatus
		{
			set{hireDateStatus = value;}
			get{return hireDateStatus;}
		}

		private string kindOfOTStatus = NullConstant.STRING;
		public string KindOfOTStatus
		{
			set{kindOfOTStatus = value.Trim();}
			get{return kindOfOTStatus;}
		}

		private bool saturdayBreak;
		public bool SaturdayBreak
		{
			set{saturdayBreak = value;}
			get{return saturdayBreak;}
		}

		private bool sundayBreak;
		public bool SundayBreak
		{
			set{sundayBreak = value;}
			get{return sundayBreak;}
		}

		private TraditionalHolidayPattern aTraditionalHolidayPattern;
		public TraditionalHolidayPattern ATraditionalHolidayPattern
		{
			set{aTraditionalHolidayPattern = value;}
			get{return aTraditionalHolidayPattern;}
		}

		private bool holidayTable;
		public bool HolidayTable
		{
			set{holidayTable = value;}
			get{return holidayTable;}
		}
	
//		============================== Constructor ==============================
		public HolidayCondition(): base()
		{

		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{				
				return aPositionType.EntityKey + aServiceStaffType.EntityKey + aCustomerDepartment.EntityKey + hireDateStatus + kindOfOTStatus;
			}
		}

		#region IDisposable Members
        //protected override void Dispose(bool disposing)
        //{
        //    if(!this.disposed)
        //    {
        //        try
        //        {
        //            if(disposing)
        //            {
        //                aPositionType.Dispose();
        //                aServiceStaffType.Dispose();
        //                aCustomerDepartment.Dispose();

        //                aPositionType = null;
        //                aServiceStaffType = null;
        //                aCustomerDepartment = null;
        //            }
        //            this.disposed = true;
        //        }
        //        finally
        //        {
        //            base.Dispose(disposing);
        //        }
        //    }
        //}
		#endregion

	}
}
