using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class OvertimeAmount : EntityBase, IKey
	{
//		============================== Property ==============================
		private int otYear = NullConstant.INT;
		public int OtYear
		{
			get{return otYear;}
			set{otYear = value;}
		}
	
		private byte otMonth;
		public byte OtMonth
		{
			get{return otMonth;}
			set{otMonth = value;}
		}

		private decimal otAmount = NullConstant.DECIMAL;
		public decimal OtAmount
		{
			get{return otAmount;}
			set{otAmount = value;}
		}
	
//		============================== Constructor ==============================
		public OvertimeAmount():base()
		{}

		#region IKey Members

		public override string EntityKey
		{
			get
			{
				return otYear.ToString() + otMonth.ToString();
			}
		}

		#endregion
	}
}
