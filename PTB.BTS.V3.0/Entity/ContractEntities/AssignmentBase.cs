using System;

using Entity.AttendanceEntities;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.ContractEntities
{
	public abstract class AssignmentBase : EntityBase,IKey
	{
        #region English Description

        public static class AssignmentRoleValue
        {
            public static readonly string MAIN = "M";
            public static readonly string SPARE = "S";
        }

        #endregion

//		============================== Property ==============================
		protected ContractBase aContract;
		public ContractBase AContract
		{
			get{return aContract;}
			set{aContract = value;}
		}

		protected TimePeriod aPeriod;
		public TimePeriod APeriod
		{
			get{return aPeriod;}
			set{aPeriod = value;}
		}

		protected Hirer aHirer;
		public Hirer AHirer
		{
			get{return aHirer;}
			set{aHirer = value;}
		}

//		============================== Constructor ==============================
		protected AssignmentBase(): base()
		{
			aPeriod = new TimePeriod();
			aHirer = new Hirer();
		}

		#region IKey Members
		public override string EntityKey
		{
			get
			{
				return aContract.EntityKey + aPeriod.From.ToShortDateString() +  aPeriod.To.ToShortDateString();
			}
		}
		#endregion

	}
}
