//using System;
//
//using ictus.PIS.PI.Entity;
//using Entity.CommonEntity;
//
//namespace Entity.AttendanceEntities
//{
//	public class TimeCardList : CompanyStuffBase
//	{
////		============================== Property ==============================
//		private DateTime cardDate;
//		public DateTime CardDate
//		{			
//			set{ cardDate = value;}
//			get{return  cardDate;}
//		}
//		private string dayType = NullConstant.STRING;
//		public string DayType
//		{			
//			set{ dayType = value.Trim();}
//			get{return  dayType;}
//		}
//
//		private TimePeriod aTimePeriod;
//		public TimePeriod ATimePeriod
//		{			
//			set{ aTimePeriod = value;}
//			get{return  aTimePeriod;}
//		}
//		private AttendanceStatus aBeforeBreakStatus;
//		public AttendanceStatus ABeforeBreakStatus
//		{			
//			set{ aBeforeBreakStatus = value;}
//			get{return  aBeforeBreakStatus;}
//		}
//		private AttendanceStatus aAfterBreakStatus;
//		public AttendanceStatus AAfterBreakStatus
//		{			
//			set{ aAfterBreakStatus = value;}
//			get{return  aAfterBreakStatus;}
//		}
////		============================== Constructor ==============================
//		public TimeCardList(Company company) : base(company)
//		{
//		}
//		public void Add(TimeCard aTimeCard)
//		{
//			base.Add(aTimeCard);
//		}
//
//		public void Remove(TimeCard value)
//		{
//			base.Remove(value);
//		}
//		public TimeCard this[int index]
//		{
//			get
//			{
//				return (TimeCard) base.BaseGet(index);
//			}
//			set
//			{
//				base.BaseSet(index, value);
//			}
//		}
//		public TimeCard this[String key]  
//		{
//			get
//			{
//				return (TimeCard) base.BaseGet(key);
//
//			}
//			set
//			{
//				base.BaseSet(key, value);
//			}
//		}
//
//	}
//}
