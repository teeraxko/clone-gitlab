using System;

using Entity.CommonEntity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class BenefitPayment : EntityBase, IKey
	{
//		============================== Property ==============================
		private PAYMENT_STATUS_TYPE paymentStatus = PAYMENT_STATUS_TYPE.NULL;
		public PAYMENT_STATUS_TYPE PaymentStatus
		{
			get{return paymentStatus;}
			set{paymentStatus = value;}
		}

		private DateTime paymentDate = NullConstant.DATETIME;
		public DateTime PaymentDate
		{
			get{return paymentDate;}
			set{paymentDate = value;}
		}

//		============================== Constructor ==============================
		public BenefitPayment() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return null;}
		}
	}
}
